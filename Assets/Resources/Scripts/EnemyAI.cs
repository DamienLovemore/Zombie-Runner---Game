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
   
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        //Calculates the distance between the enemy and the target
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);

        //Begins chasing the target if it gets close enough
        if(distanceToTarget <= this.chaseRange)
            //Makes the enemy AI follow the target position
            //(The player for example)
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
