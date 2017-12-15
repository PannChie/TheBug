using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour 
{
	public float speed;
	private Rigidbody rb;
	public GameObject Player;  

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter (Collider other) {

		if (Player.gameObject.CompareTag ("Inimigo")) {
			{
				Player.gameObject.SetActive (false);
				SceneManager.LoadScene (1);
			}
		}
		if (other.gameObject.CompareTag ("Bosta")) {
			other.gameObject.SetActive (false);
		}
	}
}


		
	
