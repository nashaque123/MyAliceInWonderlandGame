using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorAnimation : MonoBehaviour {
    //Play animation on trigger
    Animator animator;
    private bool trigger = false;
    public GUIStyle style;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        trigger = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
    }

    //Set animator trigger when door collides with a projectile
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
            animator.SetTrigger("OpenDoor");

        //Output message if door is tagged as spawn
        if (other.gameObject.tag == "Player" && gameObject.tag == "Spawn")
            trigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    private void OnGUI()
    {
        if (trigger)
            GUI.Label(new Rect((Screen.width / 2 - 100), 50, Screen.width, 50), "Press E to open the door!", style);
    }

    private void Update()
    {
        //Starts animation when E button pressed if door tagged as spawn
        if (gameObject.tag == "Spawn")
        {
            if (trigger && Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("OpenDoor");
                //Starts timer for mini game
                GameObject.FindWithTag("Player").GetComponent<Timer>().start = true;
            }
        }
    }
}
