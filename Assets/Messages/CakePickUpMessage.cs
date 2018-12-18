using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePickUpMessage : MonoBehaviour {
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
        //Only sets trigger to true if the projectile ability is active
        if (other.gameObject.tag == "Player" && GameObject.FindWithTag("Player").GetComponent<MasterScript>().item1Active == true)
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
            GUI.Label(new Rect((Screen.width / 2 - 150), 50, Screen.width, 50), "Press 1 to select your cake, and left click to shoot!", style);
            GUI.Label(new Rect((Screen.width / 2 - 180), 75, Screen.width, 50), "Fire a cake at the door with the correct answer to the riddle!", style);
            GUI.Label(new Rect((Screen.width / 2 - 135), 100, Screen.width, 50), "But be careful, an incorrect answer can hurt!", style);
        }
    }
}
