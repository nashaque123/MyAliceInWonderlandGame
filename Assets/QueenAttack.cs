using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QueenAttack : MonoBehaviour {
    //Applies standard variables for queen for combat
    public int health = 100;
    public int damageDealt = 10;
    public bool spotted;

    //Uses timer to delay rate of attack
    public float attackRate = 4.0F;
    private float nextAttack;

    NavMeshAgent agent;
    public Transform player;

    //Checks amount of other enemies remaining before attacking
    public int enemyCount = 10;
    public bool attacking = false;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //Trigger for queen to start attacking only true when all other enemies are dead
        if (enemyCount == 0)
            attacking = true;

        if (attacking)
        { 
            //When distance between player and queen < 30, queen follows player
            if (Vector3.Distance(transform.position, player.position) < 30)
                spotted = true;

            //Will always follow player even if distance increases back to above 30 to prevent player running away
            if (spotted)
                agent.destination = player.position;

            //Puts delay on attack to prevent player losing health every frame
            if (Vector3.Distance(transform.position, player.position) < 4.0F && Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                player.GetComponent<MasterScript>().health -= damageDealt;
            }

            //Destroys when health is 0 or lower
            if (health <= 0)
                Destroy(gameObject);

        }
    }

    //Checks collisions with projectiles
    public void OnCollisionEnter(Collision collision)
    {
        if (attacking)
            if (collision.gameObject.tag == "Projectile")
                health -= player.GetComponent<MasterScript>().projectileDamage;
    }
}
