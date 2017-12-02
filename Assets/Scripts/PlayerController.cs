using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private Rigidbody rb;
	public bool onGround; // Sphere grounded or not

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) { // And if the player press Space

				rb.velocity = new Vector3 (0f, 5f, 0f); // The sphere will jump
				onGround = false; // The sphere can't jump if it's in the air
			}

		}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
}