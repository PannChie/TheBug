using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTorii1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTrigger (Collider hit){

		if (hit.tag == "Player") {

			SceneManager.LoadScene (1);
		}
	}
}
