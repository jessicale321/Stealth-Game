using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{

    NavMeshAgent myNavMeshAgent;
    public Transform target;
    public float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity; // start out with player out of range

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); // distance between player & this enemy
        
        // chase if player is close
        if (distanceToTarget <= chaseRange) {
            myNavMeshAgent.SetDestination(target.position);
        }
        

    }
}
