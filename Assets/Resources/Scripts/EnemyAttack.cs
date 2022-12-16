using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{   
    [Tooltip("The amount of damage the enemy deals per attack")]
    [SerializeField] private float damage = 40f;

    private PlayerHealth target;

    void Start()
    {
        this.target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(this.target == null)
            return;

        this.target.TakeDamage(this.damage);
    }    
}
