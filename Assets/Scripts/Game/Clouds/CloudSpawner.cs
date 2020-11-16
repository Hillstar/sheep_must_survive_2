using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject[] clouds;
    public float spawnDelay = 10f;

    private float _timeToSpawn;

	// Use this for initialization
	private void Start ()
	{
		SpawnCloud();
    }
	
	// Update is called once per frame
	private void Update ()
	{
		if (_timeToSpawn <= Time.time)
            SpawnCloud();
	}

    void SpawnCloud()
    {
        var newPos = new Vector3(transform.position.x, Random.Range(0.5f, 6.5f), transform.position.z);
        Instantiate(clouds[Random.Range(0, clouds.Length)], newPos, Quaternion.identity);
        _timeToSpawn = Time.time + spawnDelay;
    }
}
