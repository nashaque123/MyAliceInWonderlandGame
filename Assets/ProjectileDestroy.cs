using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour {
    //Destroys projectile after 2.5 scaled seconds from firing
	// Use this for initialization
	void Start () {

        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
