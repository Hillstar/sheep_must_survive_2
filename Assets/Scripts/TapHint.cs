using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHint : MonoBehaviour {
	
	// Update is called once per frame
	public void Update () 
	{
		Debug.Log(Input.touchCount);
        if (Input.touchCount > 0 || !GameManager.isPlayerAlive)
            Destroy(gameObject);
	}
}
