using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 5;
    [SerializeField] private AmmoType ammoType;

    //When the player touches the ammo, it should increase
    //its ammo amount for the type of ammo colected
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Ammo playerAmmoStorage = FindObjectOfType<Ammo>();
            playerAmmoStorage.IncreaseCurrentAmmo(this.ammoType, this.ammoAmount);

            Destroy(this.gameObject);
        }
    }
}
