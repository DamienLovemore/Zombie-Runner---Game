using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("The maximum amount of health of the player")]
    [SerializeField] private float playerMaxHealth = 100f;

    private float health;

    void Start()
    {
        //Sets its health to be full health in the beginning
        this.health = playerMaxHealth;
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

    //Destroys the player
    private void Die()
    {
        Debug.Log("I died");
    }
}
