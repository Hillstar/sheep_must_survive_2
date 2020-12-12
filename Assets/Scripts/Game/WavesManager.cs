using UnityEngine;

namespace Game
{
    public class WavesManager : MonoBehaviour
    {
        public int numWaves = 3;
        //public float waveDelay = 2.0f;

        //private float _timeNewWave;
        private int _curWaveNum;
    
        private void Update()
        {
            if(_curWaveNum < numWaves) 
            {
                if(GameManager.gameState == GameStates.BreakEnded) // если закончилась волна, обновляем таймер и ждем
                {
                    //GameManager.gameState = GameStates.Break;
                    //_timeNewWave = Time.time + waveDelay;
                    GameManager.gameState = GameStates.WaveRunning;
                    _curWaveNum++;
                }
                // Начать новую волну
                /*
                else if(GameManager.gameState == GameStates.Break && Time.time >= _timeNewWave)
                {
                    GameManager.gameState = GameStates.WaveRunning;
                }
                */
            }
            else
            {
                GameManager.gameState = GameStates.GameOver;
            }
        }
    }
}
