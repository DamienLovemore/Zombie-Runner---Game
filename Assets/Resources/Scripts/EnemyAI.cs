using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;

    private NavMeshAgent navMeshAgent;
    //Stats with the enemy being away from the player
    //(To prevent enemies from chasing the player in the start)
    private float distanceToTarget = Mathf.Infinity;
    //If the enemy was shot it should keep following even if not
    //within the chaseRange
    private bool isProvoked;
    private Animator animator;
   
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        this.animator = GetComponent<Animator>();
    }
    
    void Update()
    {
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

    //Attacks the target
    private void AttackTarget()
    {
        this.animator.SetBool("Attack", true);    
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
