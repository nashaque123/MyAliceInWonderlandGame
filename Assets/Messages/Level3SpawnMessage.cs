using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3SpawnMessage : MonoBehaviour {
    //Displays message on trigger
    private bool trigger = false;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
        style.fontSize = 20;
        style.normal.textColor = Color.red;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            trigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
    }
	
	// Update is called once per frame
	void OnGUI () {

        if (trigger)
        {
            GUI.Label(new Rect((Screen.width / 2 - 130), 50, Screen.width, 50), "Welcome to the Queen's game of croquet!", style);
            GUI.Label(new Rect((Screen.width / 2 - 130), 75, Screen.width, 50), "Use the flamingo to win at all 3 holes!", style);
        }
    }
}