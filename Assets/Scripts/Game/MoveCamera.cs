using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {

        if (target != null && transform.position != target.transform.position)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 6f, transform.position.z);
        }
    }
}
