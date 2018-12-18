using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingWeapon : MonoBehaviour {
    //Plays melee weapon animation on mouse button press
    Animator animator;
    public GameObject target;

    // Use this for initialization
    void Start () {
        //Control animation of melee weapon by using trigger on animator
        animator = GameObject.FindWithTag("Pivot").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Play animation if left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Attack");
	}

    //Checks if the weapon has a target when animation is playing
    //Reduces the health of target
    public void Attack()
    {
        if (target.GetComponent<GetTarget>().checkTarget)
        {
            GameObject enemy = GameObject.FindWithTag("MeleeWeapon").GetComponent<GetTarget>().target;

            if (enemy.gameObject.tag == "Enemy")
                enemy.gameObject.transform.GetComponent<EnemyAttack>().health -= 15;
            else if (enemy.gameObject.tag == "Queen")
            {
                if (GameObject.FindWithTag("Queen").GetComponent<QueenAttack>().attacking)
                    enemy.gameObject.transform.GetComponent<QueenAttack>().health -= 15;
            }
            
        }
    }
}
