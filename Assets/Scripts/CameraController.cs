using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {
 
	public Transform Target;
	public float cameraSpeed = 15;
	public float zOffset = 22;
	public bool smoothFollow = true;

	void Update ()
	{
		if (Target) {
			Vector3 newPos = transform.position;
			newPos.x = Target.position.x;
			newPos.z = Target.position.z - zOffset;
		

			if (!smoothFollow)
				transform.position = newPos;
			else
				transform.position = Vector3.Lerp (transform.position, newPos, cameraSpeed * Time.deltaTime);
		}

	}
}