using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportHandler : MonoBehaviour {
    //Doesn't destroy player stats and information when teleporting from scene to scene
    private bool created = false;

	// Use this for initialization
	void Awake () {
		
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
	}
}
