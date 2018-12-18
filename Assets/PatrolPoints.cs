using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolPoints : MonoBehaviour {
    //Allows queen to move to next hole when player scores in golf/croquet
    NavMeshAgent agent;
    public Transform[] points;
    private int destination = 0;
    public bool ball1Potted = false;
    public bool ball2Potted = false;
    public bool ball3Potted = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();	
	}
	
	// Update is called once per frame
	void Update () {
        //Checks if queen is attacking the player
        if (!(GameObject.FindWithTag("Queen").GetComponent<QueenAttack>().attacking) && !(GameObject.FindWithTag("Queen").GetComponent<QueenAttack>().spotted))
        {
            //Changes target point for patrol depending on which section of game they are on
            agent.destination = points[destination].position;

            if (ball1Potted)
                destination = 1;

            if (ball2Potted)
                destination = 2;

            if (ball3Potted)
                destination = 3;
        }
	}
}
