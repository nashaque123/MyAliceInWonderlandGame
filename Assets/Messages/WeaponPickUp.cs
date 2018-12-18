using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {
    //Displays message on trigger
    private bool trigger;
    public GUIStyle style;

    // Use this for initialization
    void Start()
    {
        trigger = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameObject.FindWithTag("Player").GetComponent<MasterScript>().item2Active == true)
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
            GUI.Label(new Rect((Screen.width / 2 - 150), 50, Screen.width, 50), "Press 2 to select your weapon, and left click to swing!", style);
            GUI.Label(new Rect((Screen.width / 2 - 140), 75, Screen.width, 50), "Pot the ball then follow the queen to the next hole", style);
        }
    }
}
