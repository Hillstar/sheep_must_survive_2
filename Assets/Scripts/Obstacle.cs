﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speedDown = 5f;
    public float speedUp = 1f;

    Vector3 dir = Vector3.down;
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y >= 25f)
            Destroy(gameObject);

        else if(transform.position.y <= 4.5f)
            {
                dir = Vector3.up;
                speedDown = 3f;
            }

        transform.Translate(dir * Time.deltaTime * speedDown, Space.World);	
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            Destroy(col.gameObject);
    }
}