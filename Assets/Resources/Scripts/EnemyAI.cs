using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent navMeshAgent;
   
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        //Makes the enemy AI follow the target position
        //(The player for example)
        this.navMeshAgent.SetDestination(this.target.position);
    }
}
