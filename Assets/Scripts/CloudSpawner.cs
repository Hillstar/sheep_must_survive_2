using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject[] clouds;
    public float spawnDelay = 10f;

    float timeToSpawn;

	// Use this for initialization
	void Start () {

        SpawnCloud();
    }
	
	// Update is called once per frame
	void Update () {

        if (timeToSpawn <= Time.time)
            SpawnCloud();
	}

    void SpawnCloud()
    {
        Vector3 newPos = new Vector3(transform.position.x, Random.Range(0.5f, 6.5f), transform.position.z);
        Instantiate(clouds[Random.Range(0, clouds.Length)], newPos, Quaternion.identity);
        timeToSpawn = Time.time + spawnDelay;
    }
}
