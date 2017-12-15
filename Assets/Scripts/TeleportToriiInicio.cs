using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToriiInicio : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hit){

		if (hit.tag == "Player, Inimigo") {

			SceneManager.LoadScene (2);
		}
			
	}
}
