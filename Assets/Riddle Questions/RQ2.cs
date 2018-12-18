using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RQ2 : MonoBehaviour {
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

    public void OnTriggerEnter(Collider collider)
    {
        trigger = true;
    }

    public void OnTriggerExit(Collider collider)
    {
        trigger = false;
    }

    void OnGUI()
    {
        if (trigger)
            GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "What do you call a bear with no ear?", style);
    }
}
