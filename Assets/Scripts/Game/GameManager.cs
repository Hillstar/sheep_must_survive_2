using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour 
    {
        public static int money;
        public static int numSheep;
        public static bool hereSheep;
        public static bool isPlayerAlive;
        public static bool isntMute = true;
        public static GameObject[] sheeps;
        public static GameStates gameState;

        // GameObject[] characters;
    
        private void Awake ()
        {
            var sheeps = GameObject.FindGameObjectsWithTag("Sheep");
            numSheep = sheeps.Length;
            isPlayerAlive = true;
            money = 0;
            hereSheep = false;
            AudioListener.volume = isntMute ? 1 : 0;
            gameState = GameStates.WaveRunning;

            //var startPos = new Vector3(-14f, -4.12f, 0f);
            //Instantiate(characters[PlayerPrefs.GetInt("CurrentChar")], startPos, Quaternion.identity);
        }

        private void Update()
        {
            sheeps = GameObject.FindGameObjectsWithTag("Sheep"); // TODO: Лучше переделать, может быть дорого
            Debug.LogError(gameState);

            if (!isPlayerAlive) //  || numSheep < 1
            {
                gameState = GameStates.GameOver;
            }
        }
    }
}
