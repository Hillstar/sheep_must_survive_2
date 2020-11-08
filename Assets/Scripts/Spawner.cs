using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject obstacle;
    public float spawnDelay = 2f;

    private float _timeToSpawn;
    private int _currentSpawner;

	// Use this for initialization
	private void Start () 
	{

        _timeToSpawn = Time.time + spawnDelay + 2;
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if(Time.time >= _timeToSpawn)
        {
            _currentSpawner = Random.Range(0, spawners.Length);
            Instantiate(obstacle, spawners[_currentSpawner].transform.position, Quaternion.identity);
            _timeToSpawn = Time.time + spawnDelay;
        }
	}
}
