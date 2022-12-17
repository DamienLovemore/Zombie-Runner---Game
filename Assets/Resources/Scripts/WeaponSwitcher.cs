using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int currentWeapon = 0;

    void Start()
    {
        this.SetWeaponActive();
    }
    
    //Set the right weapon to be active, and disable the others
    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        //Cycle trough this gameObject children
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == this.currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    void Update()
    {
        
    }
}
