using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter1 : MonoBehaviour {
    //Loads different scenes depending on players tag
    private bool message;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
        message = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShrinkPotion")
        {
            SceneManager.LoadScene("Underground", LoadSceneMode.Additive);
            other.transform.position = new Vector3(1024, 349, 420);
            other.gameObject.tag = "Player";
            message = false;
        }
        else if (other.gameObject.tag == "GrowPotion")
        {
            //Deactivates throwing projectiles to prevent using them at the golf minigame
            SceneManager.MoveGameObjectToScene(other.gameObject, SceneManager.GetSceneByName("Aboveground"));
            other.transform.position = new Vector3(40, 1, 305);
            other.GetComponent<MasterScript>().item1Active = false;
            other.GetComponent<MasterScript>().ammo = 30;
            other.gameObject.tag = "Player";
        }
        else if (other.gameObject.tag == "Player")
        {
            message = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        message = false;
    }

    //Displays message to find potion if tag is incorrect
    private void OnGUI()
    {
        if (message)
            GUI.Label(new Rect((Screen.width / 2 - 120), 50, Screen.width, 50), "Have you drank the potion yet?", style);
            
    }
}
