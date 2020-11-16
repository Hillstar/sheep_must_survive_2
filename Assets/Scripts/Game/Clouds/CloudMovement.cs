using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    public float speed = 1.5f;
	
	// Update is called once per frame
	private void Update () 
	{
		transform.Translate(Vector3.right * (Time.deltaTime * speed), Space.World);
	}
}
