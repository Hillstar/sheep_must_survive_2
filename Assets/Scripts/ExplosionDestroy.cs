﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        Destroy(gameObject, 2f);
	}
}