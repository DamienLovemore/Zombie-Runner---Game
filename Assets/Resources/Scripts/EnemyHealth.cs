using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("The maximum amount of health of the enemy")]
    [SerializeField] private float enemyMaxHealth = 100f;
    
    private Animator animator;
    private float health;
    private bool isDead;
        
    void Start()
    {
        //Sets its health to be full health in the beginning
        this.health = enemyMaxHealth;
        this.animator = GetComponent<Animator>();
    }
        
    public bool  IsDead()
    {
        return this.isDead;
    }

    //Reduces the enemy health by the amount of damage received
    public void TakeDamage(float hitPoints)
    {
        //Cals the method named OnDamageTaken on every script in
        //this game object or its children(signals enemy to start
        //attacking)
        BroadcastMessage("OnDamageTaken");

        //Reduces the enemy health by the hitPoints, and add protection
        //to avoid enemy having health outside 0 and its max health
        this.health = Mathf.Clamp(this.health - hitPoints, 0f, this.enemyMaxHealth);

        if(this.health == 0)
        {
            this.Die();
        }        
    }

    //Kills the enemy
    private void Die()
    {
        //If the enemy is already dead, do not trigger death again
        if (this.isDead)
            return;

        this.isDead = true;
        this.animator.SetTrigger("Die");
        this.gameObject.tag = "Corpse";
    }
}
