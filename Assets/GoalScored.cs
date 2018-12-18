using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScored : MonoBehaviour {
    //Tells queen when the player has scored in the golf game
    private GameObject queen;

	// Use this for initialization
	void Start () {
        queen = GameObject.FindWithTag("Queen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);

            //Tells queen to change patrol point to next hole
            if (!(queen.GetComponent<PatrolPoints>().ball1Potted))
                queen.GetComponent<PatrolPoints>().ball1Potted = true;
            else if (queen.GetComponent<PatrolPoints>().ball1Potted && !(queen.GetComponent<PatrolPoints>().ball2Potted))
                queen.GetComponent<PatrolPoints>().ball2Potted = true;
            else if (queen.GetComponent<PatrolPoints>().ball1Potted && queen.GetComponent<PatrolPoints>().ball2Potted && !(queen.GetComponent<PatrolPoints>().ball3Potted))
                queen.GetComponent<PatrolPoints>().ball3Potted = true;
        }
    }
}
