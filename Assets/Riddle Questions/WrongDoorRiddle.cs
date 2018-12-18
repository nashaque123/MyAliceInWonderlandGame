using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongDoorRiddle : MonoBehaviour {
    //Reduces player health by 5 if they choose incorrect answer
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
            GameObject.FindWithTag("Player").GetComponent<MasterScript>().health -= 5;
    }
}