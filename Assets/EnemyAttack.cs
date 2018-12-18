using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {
    //Applies standard variables for enemies for combat
    public int health = 30;
    public int damageDealt = 5;
    public bool spotted;

    //Uses timer to delay rate of attack
    public float attackRate = 4.0F;
    private float nextAttack;
    
    NavMeshAgent agent;
    public Transform player;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {

        //Enemies follow player when within distance
        if (Vector3.Distance(transform.position, player.position) < 30)
            spotted = true;

        //Always follows even if distance increases back to above 30 to prevent player running away
        if(spotted)
            agent.destination = player.position;

        //Puts delay on attack to prevent player losing health every frame
        if (Vector3.Distance(transform.position, player.position) < 4.0F && Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            player.GetComponent<MasterScript>().health -= damageDealt;
        }

        //Destroys when health is 0 or lower and reduces enemyCount from the QueenAttack script
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindWithTag("Queen").GetComponent<QueenAttack>().enemyCount--;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
            health -= player.GetComponent<MasterScript>().projectileDamage;
        
    }
}
