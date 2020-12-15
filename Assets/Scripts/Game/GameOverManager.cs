using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameOverManager : MonoBehaviour 
    {
        public AudioSource audioS;
        public EnemySpawner wavesManager;
        public Button retryBut;
        public Button goMenuBut;

        private Animator _anim;
        private bool _goMenu = false;
        private bool _retry = false;
        private float _timeToGo;
        private bool _gameStopped;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }
    
        private void Update () 
        {
            if(!_gameStopped && GameManager.gameState == GameStates.GameOver)
            {
                _gameStopped = true;
                if(wavesManager.numWaves > PlayerPrefs.GetInt("Highscore"))
                    PlayerPrefs.SetInt("Highscore", wavesManager.numWaves);
                _anim.SetTrigger("GameOver");

                retryBut.gameObject.SetActive(true);
                goMenuBut.gameObject.SetActive(true);
            }

            if(_goMenu && Time.time >= _timeToGo)
                SceneManager.LoadScene("MainMenu");

            if(_retry && Time.time >= _timeToGo)
            {
                SceneManager.LoadScene("Game");
                /*
                switch (PlayerPrefs.GetInt("CurrentTheme"))
                {
                    case 0:
                        SceneManager.LoadScene("Game");
                        break;

                    case 1:
                        SceneManager.LoadScene("Game_City");
                        break;

                    case 2:
                        SceneManager.LoadScene("Game_Beach");
                        break;
                }
                */
            }
        }

        public void PlayAgain()
        {
            _anim.SetTrigger("FadeScreen");
            _retry = true;
            _timeToGo = Time.time + 0.3f;
        }

        public void GoMainMenu()
        {
            _anim.SetTrigger("FadeScreen");
            _goMenu = true;
            _timeToGo = Time.time + 0.3f;
        }

        private void SetNewHighscore()
        {
            if(GameManager.money > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", GameManager.money);
            }
        }

        private void AddCoins(int score)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + score * 5); // не забудь исправить!!!
        }
    }
}