using UnityEngine;

namespace Game
{
    public class WavesManager : MonoBehaviour
    {
        public int numWaves = 3;
        public float waveDelay = 2.0f;

        private float _timeNewWave;
        private int _curWaveNum;
    
        private void Update()
        {
            if(_curWaveNum < numWaves) 
            {
                if(GameManager.gameState == GameManager.GameStates.WaveEnded) // если закончилась волна, обновляем таймер и ждем
                {
                    GameManager.gameState = GameManager.GameStates.Break;
                    _timeNewWave = Time.time + waveDelay;
                    _curWaveNum++;
                }
                else if(GameManager.gameState == GameManager.GameStates.Break && Time.time >= _timeNewWave)
                {
                    GameManager.gameState = GameManager.GameStates.WaveRunning;
                }
            }
            else
            {
                GameManager.gameState = GameManager.GameStates.WaveEnded;
            }
        }
    }
}
