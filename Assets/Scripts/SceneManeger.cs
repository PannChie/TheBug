using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour {

	public string nomeDaCenaAtual;

	// Use this for initialization
	void Start () {

		nomeDaCenaAtual = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene ("InfernoTokastu1");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
