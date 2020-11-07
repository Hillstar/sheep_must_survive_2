using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSheeps : MonoBehaviour {

    public GameObject Sheep;
    public float spawnDelay = 3f;

    Transform player;
    float timeToSpawn;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnSheep();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn && !GameManager.hereSheep)
            SpawnSheep();
    }

    void SpawnSheep()
    {
        float newXPos = Random.Range(-26f, 26f);

        if(newXPos > player.position.x + 10f || newXPos < player.position.x - 10f) //если рядом, то не спавнить
        {
            Vector3 newPos = new Vector3(newXPos, transform.position.y, transform.position.z);
            Instantiate(Sheep, newPos, Quaternion.identity);
            GameManager.hereSheep = true;
            timeToSpawn = Time.time + spawnDelay;
        }
    }
}
