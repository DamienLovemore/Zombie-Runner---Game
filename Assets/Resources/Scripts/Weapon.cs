using System.Collections;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [Header("Aim target")]
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float ZoomOutFOV = 40f;

    [Header("Weapon config")]
    [Tooltip("How far the bullet of the weapon can get")]
    [SerializeField] private float bulletRange = 100f;
    [Tooltip("Amount of hit points inflicted per shot")]
    [SerializeField] private float damage = 30f;
    [Tooltip("The amount of seconds to wait between each shot")]
    [SerializeField] private float timeBetweenShots = 0.5f;

    [Header("VFXs")]
    [Tooltip("Visual effect played when the weapon shoots")]
    [SerializeField] private ParticleSystem muzzleFlash;
    [Tooltip("Visual effect played when the bullet hits something")]
    [SerializeField] private GameObject hitEffect;

    [Header("Ammunition")]    
    [Tooltip("The slot that stores all the types of ammos")]
    [SerializeField] private Ammo ammoSlot;
    [Tooltip("The type of ammo this weapon use")]
    [SerializeField] private AmmoType ammoType;
    [Tooltip("The text UI that displays the current ammo amount")]
    [SerializeField] private TextMeshProUGUI textAmmo; 

    private bool canShoot = true;

    //When switching the weapon set it to be able to shoot
    //again, even if the other weapon was on cooldown.
    void OnEnable() 
    {
        //Re-enable the shooting
        this.canShoot = true;        
    }

    void Update()
    {
        //Updates the ammo count to display
        //this weapon ammo
        this.DisplayAmmo();
    }

    private void OnFire()
    {
        if(this.canShoot)
        {
            StartCoroutine(this.Shoot());
        }
    }

    //Display the current ammo of this weapon in the screen
    private void DisplayAmmo()
    {
        int currentAmmo = this.ammoSlot.GetCurrentAmmo(this.ammoType);

        textAmmo.text = currentAmmo.ToString();
    }

    //Shoots using the current weapon
    private IEnumerator Shoot()
    {
        this.canShoot = false;

        //If it does have enough ammo do shoot
        if (this.ammoSlot.GetCurrentAmmo(this.ammoType) > 0)
        {
            //Shoot a bullet
            PlayMuzzleFlash();
            ProcessRaycast();

            //Decreases ammo amount
            this.ammoSlot.ReduceCurrentAmmo(this.ammoType);
        }

        //Wait for a while before shooting again
        yield return new WaitForSeconds(this.timeBetweenShots);
        this.canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        this.muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        bool hittedSomething;

        //Cast a invisible ray into a direction to see if it hits something
        //Starting position, ray direction, ray hit information  and how far it should go
        //(When using ray direction use GameObject.transform.direction, not Vector3.direction,
        //to consider its rotation and actual position in the world)
        hittedSomething = Physics.Raycast(this.FPCamera.transform.position, this.FPCamera.transform.forward, out hit, bulletRange);

        //Verifies if it has hitted something or not
        if (hittedSomething)
        {
            this.CreateHitImpact(hit);

            //Verifies it has hitted an enemy (not a object)
            EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();
            if (targetHealth != null)
            {
                //Decreases enemy health
                targetHealth.TakeDamage(this.damage);
            }
        }
    }

    //Play a hit impact effect where the bullet hitted
    //(If it has hitted something)
    private void CreateHitImpact(RaycastHit hit)
    {
        //Instanties the hit effect on the target
        GameObject hitEffect = Instantiate(this.hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroys it after it has been shown
        Destroy(hitEffect, 0.1f);
    }
}
