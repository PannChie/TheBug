using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporteTorii1 : MonoBehaviour {

	void OnTrigger (Collider hit){
		
		if (hit.tag == "Player"){
			
			SceneManager.LoadScene (1);
		}
	}
}
