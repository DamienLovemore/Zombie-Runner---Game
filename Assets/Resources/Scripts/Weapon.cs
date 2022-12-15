using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Aim target")]
    [SerializeField] private Camera FPCamera;

    [Header("Weapon config")]
    [SerializeField] private float bulletRange = 100f;
    [SerializeField] private float damage = 30f;

    [Header("VFXs")]
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;

    private void OnFire()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
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
