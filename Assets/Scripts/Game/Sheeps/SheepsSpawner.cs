using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepsSpawner : MonoBehaviour 
{
    public GameObject sheep;
    public float spawnDelay = 3f;

    private Transform _player;
    private float _timeToSpawn;

    // Use this for initialization
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnSheep();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= _timeToSpawn && !GameManager.hereSheep)
            SpawnSheep();
    }

    private void SpawnSheep()
    {
        var newXPos = Random.Range(-26f, 26f);

        if(newXPos > _player.position.x + 10f || newXPos < _player.position.x - 10f) // если рядом, то не спавнить
        {
            var newPos = new Vector3(newXPos, transform.position.y, transform.position.z);
            Instantiate(sheep, newPos, Quaternion.identity);
            GameManager.hereSheep = true;
            _timeToSpawn = Time.time + spawnDelay;
        }
    }
}
