using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGSpawnMessage : MonoBehaviour {
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
        if (other.gameObject.tag == "Player")
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
            GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "Welcome to the Mad Hatter's house!", style);
            GUI.Label(new Rect((Screen.width / 2 - 160), 75, Screen.width, 50), "A timed event starts as soon as you exit the door!", style);
        }
    }
}
