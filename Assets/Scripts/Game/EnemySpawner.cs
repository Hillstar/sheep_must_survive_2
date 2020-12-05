using UnityEngine;

namespace Game
{
    public class EnemySpawner : MonoBehaviour
    {
        //public GameObject[] enemies; 
        public GameObject enemy; // TODO: когда будет несколько видов врагов, переделать
        public int numToSpawn = 3;
        public float spawnDelay = 5.0f;
        public Transform[] spawnPoints;
    
        private float _timeToSpawn;
        private int _numOfSpawned;
    
        private void Update()
        {
            if(_numOfSpawned < numToSpawn) 
            {
                if(GameManager.gameState == GameManager.GameStates.WaveRunning && Time.time >= _timeToSpawn)
                {
                    var spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    var currentSpawnPoint = spawnPoints[spawnPointIndex];
                    Instantiate(enemy, currentSpawnPoint.transform.position, Quaternion.identity);
                    _timeToSpawn = Time.time + spawnDelay;
                    _numOfSpawned++;
                }
            }
            else // если волна закончилась
            {
                _numOfSpawned = 0;
                GameManager.gameState = GameManager.GameStates.WaveEnded;
            }
        }
    }
}
