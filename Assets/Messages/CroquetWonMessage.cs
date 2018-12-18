﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroquetWonMessage : MonoBehaviour {
    //Displays message on trigger
    public bool trigger = false;
    public GUIStyle style;

    // Use this for initialization
    void Start()
    {
        style.fontSize = 20;
        style.normal.textColor = Color.red;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameObject.FindWithTag("Queen").GetComponent<PatrolPoints>().ball3Potted)
            trigger = true;
    }

    public void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    public void OnGUI()
    {
        if (trigger)
        {
            GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "Well done! You have beaten the queen!", style);
            GUI.Label(new Rect((Screen.width / 2 - 114), 75, Screen.width, 50), "Follow her to her important meeting!", style);
        }
    }
}