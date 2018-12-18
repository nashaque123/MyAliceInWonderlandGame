using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour {
    //Uses bool variables to check if there is an enemy within range
    public GameObject target;
    public bool checkTarget = false;
	
	// Update is called once per frame
	void Update () {

        //checkTarget changes to false if no enemy within target range or target dies
		if (checkTarget && target == null)
        {
            checkTarget = !checkTarget;
        }
	}

    //Makes colliding gameobject the target if it's tagged as enemy or queen
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Queen")
        {
            target = other.gameObject;
            checkTarget = true;
        }
    }

    //Removes gameobject from target when out of range
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            target = null;
            checkTarget = false;
        }
    }
}
