using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMessage : MonoBehaviour {
    //Displays message on trigger
    public bool trigger = false;
    public GUIStyle style;

    // Use this for initialization
    void Start()
    {
        style.fontSize = 20;
        style.normal.textColor = Color.red;
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Queen") == null)
            trigger = false;
    }

    //Reactivates the projectile ability before the battle
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameObject.FindWithTag("Queen").GetComponent<QueenAttack>().enemyCount > 0)
        {
            other.GetComponent<MasterScript>().item1Active = true;
            trigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    public void OnGUI()
    {
        if (trigger)
        {
            GUI.Label(new Rect((Screen.width / 2 - 75), 50, Screen.width, 50), "Oh no! This is an ambush!", style);
            GUI.Label(new Rect((Screen.width / 2 - 175), 75, Screen.width, 50), "Use your cakes and your flamingo to defeat the queen's minions!", style);
        }
    }
}
