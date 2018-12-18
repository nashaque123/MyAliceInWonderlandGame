using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMessage : MonoBehaviour {
    //Displays message on trigger
    public bool trigger = false;
    public GUIStyle style;

    // Use this for initialization
    void Start()
    {
        style.fontSize = 20;
        style.normal.textColor = Color.red;
    }

    public void OnTriggerStay(Collider other)
    {
        //Sets trigger to true if the queen exists
        if (other.gameObject.tag == "Player" && GameObject.FindWithTag("Queen") == null)
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
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
