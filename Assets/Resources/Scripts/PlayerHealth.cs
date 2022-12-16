using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("The maximum amount of health of the player")]
    [SerializeField] private float playerMaxHealth = 100f;

    private float health;
    private DeathHandler deathHandler;

    void Start()
    {
        //Sets its health to be full health in the beginning
        this.health = playerMaxHealth;
        this.deathHandler = this.GetComponent<DeathHandler>();
    }

    //Reduces the player health by the amount of damage received
    public void TakeDamage(float hitPoints)
    {
        //Reduces the player health by the hitPoints, and add protection
        //to avoid player having health outside 0 and its max health
        this.health = Mathf.Clamp(this.health - hitPoints, 0, this.playerMaxHealth);

        if(this.health == 0)
        {
            this.Die();
        }
    }

    //Kills the player
    private void Die()
    {
        this.deathHandler.HandleDeath();
    }
}
