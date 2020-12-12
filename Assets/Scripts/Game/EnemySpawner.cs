using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Game
{
    public class EnemySpawner : MonoBehaviour
    {
        public static int deadEnemiesCounter;
        public GameObject[] enemies;
        public int numToSpawn = 3;
        public float spawnDelay = 5.0f;
        public Transform[] spawnPoints;
    
        private float _timeToSpawn;
        private int _numOfSpawned;

        private void Start()
        {
            deadEnemiesCounter = 0;
        }

        private void Update()
        {
            if(_numOfSpawned < numToSpawn) 
            {
                if(GameManager.gameState == GameManager.GameStates.WaveRunning && Time.time >= _timeToSpawn)
                {
                    var spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    var currentSpawnPoint = spawnPoints[spawnPointIndex];
                    var currentEnemy = Random.Range(0, enemies.Length);
                    Instantiate(enemies[currentEnemy], currentSpawnPoint.transform.position, Quaternion.identity);
                    _timeToSpawn = Time.time + spawnDelay;
                    _numOfSpawned++;
                }
            }
            else if(deadEnemiesCounter == numToSpawn) // если волна закончилась
            {
                _numOfSpawned = 0;
                deadEnemiesCounter = 0;
                GameManager.gameState = GameManager.GameStates.WaveEnded;
                
                // Increase difficulty
                numToSpawn += 2;
                spawnDelay *= 0.7f;
            }
        }
    }
}
