using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessage : MonoBehaviour {
    //Displays message on trigger
    private bool trigger;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
        trigger = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
	}

    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    private void OnGUI()
    {
        if (trigger)
        {
            GUI.Label(new Rect((Screen.width / 2 - 156), 50, Screen.width, 50), "Follow the rabbit but stay on the right path!", style);
            GUI.Label(new Rect((Screen.width / 2 - 155), 75, Screen.width, 50), "Use WASD to move and hold shift to sprint", style);
        }
    }
}
