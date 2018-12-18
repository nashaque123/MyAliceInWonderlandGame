using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitNavigation : MonoBehaviour {
    //Creates target for rabbit AI to use NavMesh
    public Transform goal;
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
 