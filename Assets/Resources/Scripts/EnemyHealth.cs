using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("The maximum amount of health of the enemy")]
    [SerializeField] private float enemyMaxHealth = 100f;
    
    private float health;
    
    void Start()
    {
        //Sets its health to be full health in the beginning
        this.health = enemyMaxHealth;
    }

    //Reduces the enemy health by the amount of damage received
    public void TakeDamage(float hitPoints)
    {
        //Reduces the enemy health by the hitPoints, and add protection
        //to avoid enemy having health outside 0 and its max health
        this.health = Mathf.Clamp(this.health - hitPoints, 0f, this.enemyMaxHealth);

        if(this.health == 0)
        {
            this.Die();
        }        
    }

    //Destroys the enemy
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
