using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public AudioSource audioS;
    public GameManager gm;
    public Button retryBut;
    public Button goMenuBut;

    Animator anim;
    bool goMenu = false;
    bool retry = false;
    float timeToGo;
    bool stopAddScore = false; // чтобы добавил 1 раз
    bool requestIntAd = false; // тк сцена загружается заново, его не надо менять

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameCounter == 4 && requestIntAd == false) // вызывать за одну игру до показа рекламы
        {
            requestIntAd = true;
        }

        if(!GameManager.isPlayerAlive) // передалть как в ферст май
        {
            anim.SetTrigger("GameOver");

            retryBut.gameObject.SetActive(true);
            goMenuBut.gameObject.SetActive(true);

            if(GameManager.gameCounter == 5)
            {
                GameManager.gameCounter = 0;
            }

            if(!stopAddScore)
            {
                audioS.Play();
                SetNewHighscore();
                GameManager.gameCounter++; // для рекламы

                if (GameManager.score > 0)
                    AddCoins(GameManager.score);// добавили к коинам за новых овец

                stopAddScore = true;
            }   
        }

        if(goMenu && Time.time >= timeToGo)
            SceneManager.LoadScene("MainMenu");

        if (retry && Time.time >= timeToGo)
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
        anim.SetTrigger("FadeScreen");
        retry = true;
        timeToGo = Time.time + 0.3f;
    }

    public void GoMainMenu()
    {
        anim.SetTrigger("FadeScreen");
        goMenu = true;
        timeToGo = Time.time + 0.3f;
    }

    void SetNewHighscore()
    {
        if(GameManager.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", GameManager.score);
        }
    }

    void AddCoins(int score)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + score * 5); // не забудь исправить!!!
    }
}