using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    //Starts timer and counts down
    public float timeLeft = 60.0F;
    public bool start = false;
    public bool finished = false;
	
	// Update is called once per frame
	void Update () {
        if (start)
            timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
            finished = true;
    }

    //Displays time remaining or message when time's over
    public void OnGUI()
    {
        if (start)
            GUI.Label(new Rect((Screen.width - 150), 50, Screen.width, 50), "Time remaining: " + Mathf.Round(timeLeft));
        else if (finished)
            GUI.Label(new Rect((Screen.width - 150), 50, Screen.width, 50), "Time's up! Try again");
    }
}
