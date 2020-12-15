using System;
using UnityEngine;

namespace Game
{
    public class WavesManager : MonoBehaviour
    {
        public int numWaves;

        private void Start()
        {
            numWaves = 0;
        }

        private void Update()
        {
            if(GameManager.gameState == GameStates.BreakEnded)
            {
                GameManager.gameState = GameStates.WaveRunning;
                numWaves++;
            }
        }
    }
}
