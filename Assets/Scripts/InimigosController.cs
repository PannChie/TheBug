using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class InimigosController : MonoBehaviour {
	
	public Transform Player;
	NavMeshAgent  navMesh;

	void Start (){
		navMesh = GetComponent <NavMeshAgent> ();
				
	}

	void Update ()
	{
		navMesh.SetDestination (Player.position);
	}

}