using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameOverManager : MonoBehaviour 
    {
        public AudioSource audioS;
        public GameManager gm;
        public Button retryBut;
        public Button goMenuBut;

        private Animator _anim;
        private bool _goMenu = false;
        private bool _retry = false;
        private float _timeToGo;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }
    
        private void Update () 
        {
            if(GameManager.gameState == GameManager.GameStates.GameOver)
            {
                _anim.SetTrigger("GameOver");

                retryBut.gameObject.SetActive(true);
                goMenuBut.gameObject.SetActive(true);
            }

            if(_goMenu && Time.time >= _timeToGo)
                SceneManager.LoadScene("MainMenu");

            if(_retry && Time.time >= _timeToGo)
            {
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
            if(GameManager.score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", GameManager.score);
            }
        }

        private void AddCoins(int score)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + score * 5); // не забудь исправить!!!
        }
    }
}