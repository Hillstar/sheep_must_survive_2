using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button muteButton;
    public Sprite nmSprite;
    public Sprite mSprite;
    public GameObject[] menuCharacters;
    public GameObject[] themes;

    private Image _image;
    private Animator _anim;
    private bool _goPlay;
    private bool _goShop;
    private float _timer;

    private void Awake()
    {
        FirstStart();

        //Vector3 newPos = new Vector3(0f, 0f, 0f);
        switch (PlayerPrefs.GetInt("CurrentTheme"))
        {
            case 0:
                Instantiate(themes[0], themes[0].transform.position, Quaternion.identity);
                break;

            case 1:
                Instantiate(themes[1], themes[1].transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(themes[2], themes[2].transform.position, Quaternion.identity);
                break;
        }

        // ставим перса в главном меню
        var newPos = new Vector3(-1.9f, -4.11f, 0f);
        Instantiate(menuCharacters[PlayerPrefs.GetInt("CurrentChar")], newPos, Quaternion.identity);
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _image = muteButton.GetComponent<Image>();
        _goPlay = false;
        ChangeSprites();
    }

    public void PlayGame()
    {
        _goPlay = true;
        _timer = Time.time + 0.3f;
        _anim.SetTrigger("Play");
    }

    public void GoShop()
    {
        _goShop = true;
        _timer = Time.time + 0.3f;
        _anim.SetTrigger("Play");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (_goPlay && Time.time > _timer)
        {
            switch(PlayerPrefs.GetInt("CurrentTheme"))
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

        if (_goShop && Time.time > _timer)
            SceneManager.LoadScene("Shop");
    }

    public void Mute()
    {
        GameManager.isntMute = !GameManager.isntMute;
        AudioListener.volume = GameManager.isntMute ? 1 : 0;
        ChangeSprites();
    }

    public void ChangeSprites()
    {
        if (GameManager.isntMute)
            _image.sprite = nmSprite;
        else
            _image.sprite = mSprite;
    }

    private void FirstStart()
    {
        // убрать знаки ! в цифрах для сброса статов
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }

        if (!PlayerPrefs.HasKey("KateIsAv"))
        {
            PlayerPrefs.SetInt("KateIsAv", 0);
        }

        if (!PlayerPrefs.HasKey("MrIsAv"))
        {
            PlayerPrefs.SetInt("MrIsAv", 0);
        }

        if (!PlayerPrefs.HasKey("CityIsAv"))
        {
            PlayerPrefs.SetInt("CityIsAv", 0);
        }

        if (!PlayerPrefs.HasKey("BeachIsAv"))
        {
            PlayerPrefs.SetInt("BeachIsAv", 0);
        }

        if (!PlayerPrefs.HasKey("CurrentTheme"))
        {
            PlayerPrefs.SetInt("CurrentTheme", 0);
        }

        if (!PlayerPrefs.HasKey("CurrentChar"))
        {
            PlayerPrefs.SetInt("CurrentChar", 0);
        }
    }
}
