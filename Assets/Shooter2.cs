using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter2 : MonoBehaviour {
    //Allows user to shoot projectiles
    public Rigidbody bullet;

    // Update is called once per frame
    void Update ()
    {
        //Creates instances of projectile on mouse click if item active and reduces ammo count
        if (Input.GetMouseButtonDown(0) && GetComponent<MasterScript>().item1Active && GetComponent<MasterScript>().selectedItem == 1)
        {
            //Changes position of instance to slightly off the center of player to prevent collisions against player
            Rigidbody newInstance = Instantiate(bullet, (transform.position + Vector3.one), transform.rotation) as Rigidbody;
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            newInstance.AddForce(forward * 1500, ForceMode.Force);
            GameObject.FindWithTag("Player").GetComponent<MasterScript>().ammo--;
        }
	}
}
