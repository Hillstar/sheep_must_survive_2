using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour {

    public GameObject asteroid;
    public Player player;
    public float delay = 2f;
    public float maxAngle = 215f;
    public float minAngle = 155f;
    public float maxLength = 8f;
    public float minLength = -8f;
    public bool ifMainMenu = false;
    
    float timeToSpawn;
    float spawnRotation;
    Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
        if (!ifMainMenu)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        else
            player = null;

        timeToSpawn = Time.time + delay + 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!ifMainMenu && Time.time >= timeToSpawn && GameManager.isPlayerAlive)
        {
            spawnRotation = Random.Range(minAngle, maxAngle);

            if(player.movement > 0)
                spawnPosition = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(-0.8f, maxLength), -29.5f, 29.5f), transform.position.y, transform.position.z);
            else
                spawnPosition = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(minLength, 0.8f), -29.5f, 29.5f), transform.position.y, transform.position.z);

            GameObject aster = Instantiate(asteroid, spawnPosition, transform.rotation);

            aster.transform.Rotate(0, 0, spawnRotation);

            timeToSpawn = Time.time + delay;
        }

        else if (ifMainMenu && Time.time >= timeToSpawn)
        {
            spawnRotation = Random.Range(minAngle, maxAngle);

            spawnPosition = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(minLength, maxLength), -29.5f, 29.5f), transform.position.y, transform.position.z);
           
            GameObject aster = Instantiate(asteroid, spawnPosition, transform.rotation);

            aster.transform.Rotate(0, 0, spawnRotation);

            timeToSpawn = Time.time + delay;
        }
	}
}
