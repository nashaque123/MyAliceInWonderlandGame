using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattleMessage : MonoBehaviour {
    //Displays message on trigger
    public bool trigger = false;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
        style.fontSize = 20;
        style.normal.textColor = Color.red;
	}

    public void OnTriggerEnter(Collider other)
    {
        //Checks if queen is alive
        if (GameObject.FindWithTag("Queen") != null)
        {
            //Sets trigger to true if enemy count is 0 or lower
            if (other.gameObject.tag == "Player" && GameObject.FindWithTag("Queen").GetComponent<QueenAttack>().enemyCount <= 0)
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
            GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "Well done! Now defeat the queen!", style);
    }
}
