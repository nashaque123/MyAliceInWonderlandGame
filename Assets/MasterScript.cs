using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {
    //Master script to hold player variables across scenes
    public static MasterScript masterScript;

    public int health;
    public int ammo;
    public bool item1Active;
    public bool item2Active;
    public int selectedItem;

    public int projectileDamage = 10;
    public int meleeDamage = 15;

    public Camera meleeCamera;
    public Camera projectileCamera;

    // Use this for initialization
    void Awake () {
        health = 100;
        ammo = 9999999;
        item1Active = false;
        item2Active = false;
        selectedItem = 0;

        meleeCamera.GetComponent<Camera>().enabled = false;
        projectileCamera.GetComponent<Camera>().enabled = false;
	}

    public void Update()
    {
        //Only allows user to choose a weapon if it is active
        if (Input.GetKeyDown("1"))
            selectedItem = 1;
        else if (Input.GetKeyDown("2"))
            selectedItem = 2;

        //Plays camera of weapon on top of main camera if selected
        if (item1Active && selectedItem == 1)
            projectileCamera.GetComponent<Camera>().enabled = true;
        else
            projectileCamera.GetComponent<Camera>().enabled = false;

        if (item2Active && selectedItem == 2)
            meleeCamera.GetComponent<Camera>().enabled = true;
        else
            meleeCamera.GetComponent<Camera>().enabled = false;

        if (ammo <= 0)
            item1Active = false;
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(10, (Screen.height - 100), 100, 25), "Health: " + health);

        if (item1Active && ammo <= 30)
            GUI.Box(new Rect(10, (Screen.height - 75), 100, 25), "Ammo: " + ammo);
    }
}

