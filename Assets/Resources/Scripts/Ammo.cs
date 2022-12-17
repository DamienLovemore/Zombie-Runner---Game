using UnityEngine;

//The class that manages all our ammos types
public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    //Makes the class to be visible in the editor
    [System.Serializable]
    //Each different ammo have a slot
    private class AmmoSlot
    {
        [Tooltip("The type of this ammo")]
        public AmmoType ammoType;
        [Tooltip("How many of this type of ammo the player have")]
        public int ammoAmount;
    }

    //Returns how many ammo it currently have
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        int returnValue = 0;
        
        //If it was able to find that type of ammo
        //gets the current amount of it
        AmmoSlot ammoInfo = this.GetAmmoSlot(ammoType);
        if (ammoInfo != null)
            returnValue = ammoInfo.ammoAmount;

        return returnValue;
    }

    //Reduce the amount of ammo by one
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        float newAmmoAmount;

        AmmoSlot ammoInfo = this.GetAmmoSlot(ammoType);
        if (ammoInfo != null)
        {
            //Does not let have negative ammo values
            newAmmoAmount = Mathf.Clamp(ammoInfo.ammoAmount - 1, 0, Mathf.Infinity);
            //Stores the new value as a int
            ammoInfo.ammoAmount = Mathf.RoundToInt(newAmmoAmount);
        }
    }

    //Returns the AmmoSlot instance that is used to store
    //the ammo of the type that was passed
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in this.ammoSlots)
        {
            if (slot.ammoType == ammoType)
                return slot;
        }

        return null;
    }
}
