using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour 
{
    public GameObject asteroid;
    public CharacterMovementControl characterMovementControl;
    public float delay = 2f;
    public float maxAngle = 215f;
    public float minAngle = 155f;
    public float maxLength = 8f;
    public float minLength = -8f;
    public bool ifMainMenu = false;
    public float spawnerHeight = 10f;
    
    private float _timeToSpawn;
    private float _spawnRotation;
    private Vector3 _spawnPosition;

	// Use this for initialization
	private void Start () 
    {
        if (!ifMainMenu)
            characterMovementControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovementControl>();
        else
            characterMovementControl = null;

        _timeToSpawn = Time.time + delay + 1f;
	}
	
	// Update is called once per frame
	private void Update () 
    {
        if(!GameManager.isPlayerAlive)
            return;
        transform.position = new Vector3(characterMovementControl.transform.position.x, spawnerHeight, transform.position.z);
        if(!ifMainMenu && Time.time >= _timeToSpawn && GameManager.isPlayerAlive)
        {
            _spawnRotation = Random.Range(minAngle, maxAngle);

            if(characterMovementControl.movement > 0)
                _spawnPosition = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(-0.8f, maxLength), -29.5f, 29.5f), transform.position.y, transform.position.z);
            else
                _spawnPosition = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(minLength, 0.8f), -29.5f, 29.5f), transform.position.y, transform.position.z);

            var aster = Instantiate(asteroid, _spawnPosition, transform.rotation);
            aster.transform.Rotate(0, 0, _spawnRotation);

            _timeToSpawn = Time.time + delay;
        }

        else if (ifMainMenu && Time.time >= _timeToSpawn)
        {
            _spawnRotation = Random.Range(minAngle, maxAngle);
            _spawnPosition = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(minLength, maxLength), -29.5f, 29.5f), transform.position.y, transform.position.z);
           
            var aster = Instantiate(asteroid, _spawnPosition, transform.rotation);
            aster.transform.Rotate(0, 0, _spawnRotation);

            _timeToSpawn = Time.time + delay;
        }
	}
}
