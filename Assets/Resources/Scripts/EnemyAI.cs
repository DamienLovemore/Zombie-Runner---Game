using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Config")]
    [Tooltip("How close the target can get to the enemy to be attacked")]
    [SerializeField] private float chaseRange = 5f;
    [Tooltip("How quickly the enemy face its head on the target")]
    [SerializeField] private float turnSpeed = 5f;
    
    private Transform target;
    private EnemyHealth enemyHealth;
    //Stats with the enemy being away from the player
    //(To prevent enemies from chasing the player in the start)
    private float distanceToTarget = Mathf.Infinity;
    //If the enemy was shot it should keep following even if not
    //within the chaseRange
    private bool isProvoked;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
       
    void Start()
    {
        this.enemyHealth = GetComponent<EnemyHealth>();
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        this.animator = GetComponent<Animator>();
        
        this.target = FindObjectOfType<PlayerHealth>().transform;
    }
    
    void Update()
    {
        //If the enemy is dead, it should not chase or attack
        //the player
        if(this.enemyHealth.IsDead())
        {
            this.enabled = false;
            this.navMeshAgent.enabled = false;
        }

        //Calculates the distance between the enemy and the target
        this.distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        if(this.isProvoked)
        {
            this.EngageTarget();
        }
        //Begins chasing the target if it gets close enough
        else if(this.distanceToTarget <= this.chaseRange)
        {
            this.isProvoked = true;            
        }                    
    }

    private void EngageTarget()
    {
        //When the enemy is provoked by the player, it does not matter
        //if it is moving closer, or attacking it should face its target
        this.FaceTarget();

        //If the enemy is close enough to attack then attack
        //(stopping distance is how close it should get to the target)
        if(this.distanceToTarget <= this.navMeshAgent.stoppingDistance)
        {
            this.AttackTarget();
        }
        //If it is not close enough to attack, then chase the target
        else
        {
            this.ChaseTarget();
        }
    }

    //Signals that the enemy was attacked, and should engage with the
    //player target
    public void OnDamageTaken()
    {
        this.isProvoked = true;
    }

    //Attacks the target
    private void AttackTarget()
    {
        this.animator.SetBool("Attack", true);    
    }

    private void FaceTarget()
    {
        //Makes the calculation and returns the result, without considering
        //the magnitude or distance of both
        Vector3 direction = (target.position - transform.position).normalized;
        //Creates a rotation that looks into the direction of the target
        //(Without looking up and down)
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        //Makes the enemy rotates itself from its actual position into the target position.
        //(Uses turnSpeed to be able to control how fast it turns, Time.deltaTime is used
        // for making the rotation framerate independent)
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * this.turnSpeed);
    }

    //Makes the enemy AI follow the target position
    //(The player for example)
    private void ChaseTarget()
    {
        this.animator.SetBool("Attack", false);
        this.animator.SetTrigger("Move");
        this.navMeshAgent.SetDestination(this.target.position);
    }

    //Visual representation for the enemy follow range in the editor
    //mode, for when the enemy is selected in the hierarchy.
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = new Color32(255, 105, 97, 255);
        //Draw a wire sphere with a radius of chaseRange with the
        //center on the enemy position
        Gizmos.DrawWireSphere(this.transform.position, this.chaseRange);
    }
}
