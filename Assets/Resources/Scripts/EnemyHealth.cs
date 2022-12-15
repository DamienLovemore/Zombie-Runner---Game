using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth = 100f;
    [SerializeField] private float health;
    
    void Start()
    {
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
