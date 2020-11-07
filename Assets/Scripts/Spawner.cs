using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject Obstacle;

    public float spawnDelay = 2f;

    float timeToSpawn;

    int CurrentSpawner;

	// Use this for initialization
	void Start () {

        timeToSpawn = Time.time + spawnDelay + 2;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time >= timeToSpawn)
        {
            CurrentSpawner = Random.Range(0, spawners.Length);
            Instantiate(Obstacle, spawners[CurrentSpawner].transform.position, Quaternion.identity);
            timeToSpawn = Time.time + spawnDelay;
        }
	}
}
