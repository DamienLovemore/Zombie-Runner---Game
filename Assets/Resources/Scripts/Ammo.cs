using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 10;

    //Returns how many ammo it currently have
    public int GetCurrentAmmo()
    {
        return this.ammoAmount;
    }

    //Reduce the amount of ammo by one
    public void ReduceCurrentAmmo()
    {
        this.ammoAmount--;
    }
}
