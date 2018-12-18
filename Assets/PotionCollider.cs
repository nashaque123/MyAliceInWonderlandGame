using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollider : MonoBehaviour {
    //Checks if player collides with potion
	public CharacterController controller;
    private bool trigger;
    private int correctCoroutine;

    // Use this for initialization
    void Start()
    {
        trigger = false;
        controller = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
        
        if (other.gameObject.tag == "ShrinkPotion")
        {
            correctCoroutine = 1;
        }
        else if (other.gameObject.tag == "GrowPotion")
        {
            correctCoroutine = 2;
        }
        else
        {
            correctCoroutine = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    //Starts correct function depending on the tag of the potion the player drinks
    private void Update()
    {
        if (trigger && Input.GetKeyDown(KeyCode.E))
        {
            if (correctCoroutine == 1)
                StartCoroutine("Shrink");
            else if (correctCoroutine == 2)
                StartCoroutine("Grow");
        }
    }

    //Changes size and tag of player
    void Shrink()
    {
        gameObject.tag = "ShrinkPotion";
        controller.height = 0.5F;        
    }

	void Grow()
	{
		gameObject.tag = "GrowPotion";
		controller.height = 3F;
	}
}
