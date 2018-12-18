using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTeleporterMessage : MonoBehaviour {
    //Displays message on trigger
    private bool trigger;
    public GUIStyle style;
    private bool playerTag;

    // Use this for initialization
    void Start()
    {
        trigger = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        trigger = true;

        if (other.gameObject.tag == "Player")
            playerTag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
        playerTag = false;
    }

    private void OnGUI()
    {
        if (trigger && playerTag)
        {
            GUI.Label(new Rect((Screen.width / 2 - 175), 50, Screen.width, 50), "You look a bit too big to fit down the rabbit hole", style);
            GUI.Label(new Rect((Screen.width / 2 - 165), 75, Screen.width, 50), "See if there's a shrink potion around anywhere!", style);
        }
    }
}
