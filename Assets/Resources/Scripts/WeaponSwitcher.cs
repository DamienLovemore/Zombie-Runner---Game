using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeapon = 0;

    void Start()
    {
        this.SetWeaponActive();
    }

    void Update()
    {
        //Stores the actual weapon index
        int previousWeapon = this.currentWeapon;

        this.ProcessHotkeyPress();
        this.ProcessWheelScroll();

        //Verifies if the user changed the weapon, if positive
        //them switch the weapon active
        if (previousWeapon != this.currentWeapon)
        {
            this.SetWeaponActive();
        }
    }

    //Switch to a specific weapon
    private void ProcessHotkeyPress()
    {
        //The first weapon is the pistol (1 for keyboard, but
        //0 for index)
        if(Keyboard.current.digit1Key.isPressed)
        {
            this.currentWeapon = 0;
        }
        //The second weapon is shotgun
        else if(Keyboard.current.digit2Key.isPressed)
        {
            this.currentWeapon = 1;
        }
        //The third weapon is the carbine (act as sniper)
        else if(Keyboard.current.digit3Key.isPressed)
        {
            this.currentWeapon = 2;
        }
    }

    //Switch the weapon using the mouse scroll wheel
    private void ProcessWheelScroll()
    {
        int newWeaponIndex = this.currentWeapon;

        //Gets the scroll value (X and Y)
        Vector2 mouseScroll = Mouse.current.scroll.ReadValue();
        //Filter just the vertical scroll
        //(O no scroll, 120 scroll up, -120 scroll down)
        float verticalScroll = mouseScroll.y;

        if (verticalScroll > 0)
            newWeaponIndex++;
        else if (verticalScroll < 0)
            newWeaponIndex--;

        //Clams the value between min and max, so the
        //the switching stop when reach the limit
        this.currentWeapon = Mathf.Clamp(newWeaponIndex, 0, 2);
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
}
