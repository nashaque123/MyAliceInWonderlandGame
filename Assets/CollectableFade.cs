using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFade : MonoBehaviour {
    //Destroys collectable when picked up by player
    private bool trigger;
    public GUIStyle style;

    private void Start()
    {
        trigger = false;
        style.normal.textColor = Color.red;
        style.fontSize = 20;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Prevents player from being able to pick up weapon when weapon is colliding with itself (multiple parts)
        if (collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "ShrinkPotion" && collision.gameObject.tag != "GrowPotion")
            trigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    private void Update()
    {
        //Starts function if player is within range and presses E
        if (trigger && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Fade");

            //Deactivates timer and destroys all instances of projectiles in mini game of finding correct cake
            if (gameObject.tag == "Projectile")
            {
                GameObject.FindWithTag("Player").GetComponent<MasterScript>().item1Active = true;
                GameObject[] game = GameObject.FindGameObjectsWithTag("Decoy");
                GameObject.FindWithTag("Player").GetComponent<Timer>().start = false;

                for (int i = 0; i < game.Length; i++)
                {
                    Destroy(game[i].gameObject);
                }
            }
            else if (gameObject.tag == "Weapon")
            {
                GameObject.FindWithTag("Player").GetComponent<MasterScript>().item2Active = true;
                GameObject[] game = GameObject.FindGameObjectsWithTag("Weapon");


                for (int i = 0; i < game.Length; i++)
                {
                    Destroy(game[i].gameObject);
                }
            }

            trigger = false;
        }
    }

    private void OnGUI()
    {
        if (trigger)
        {
            if (gameObject.tag == "Projectile")
                GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "Press E to pick up projectile!", style);
            else if (gameObject.tag == "Decoy")
                GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "That's not the right cake! :(", style);
            else if (gameObject.tag == "Weapon")
                GUI.Label(new Rect((Screen.width / 2 - 115), 50, Screen.width, 50), "Press E to pick up the flamingo!", style);
            else
                GUI.Label(new Rect((Screen.width / 2 - 100), 50, Screen.width, 50), "Press E to drink the potion!", style);
        }
    }

    //Alters transparency before deleting game object
    void Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            if (f <= 0.1)
            {
                Destroy(gameObject);
            }
        }
    }
}
