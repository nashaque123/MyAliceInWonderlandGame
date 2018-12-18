using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddlesCompletion : MonoBehaviour {
    //Displays message on trigger
    private bool trigger;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
        trigger = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
	}
	
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
          trigger = true;
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            trigger = false;
    }

    void OnGUI()
    {
        if (trigger)
        {
            GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "Well done! You have completed all the riddles!", style);
            GUI.Label(new Rect((Screen.width / 2 - 130), 75, Screen.width, 50), "Drink the potion and climb up the ladder to face the queen!", style);
            GUI.Label(new Rect((Screen.width / 2 - 112), 100, Screen.width, 50), "But now you only have a limited amount of cakes!", style);
        }
    }
}
