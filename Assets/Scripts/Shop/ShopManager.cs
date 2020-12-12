using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour 
{
    public Color butSel;
    public Color butNotSel;

    public Button[] charactersBut;
    public Button[] themeButton;
    public Sprite[] sprites;             // первые два Кейт (1 недоступен, 2 доступен) и тд
    public Sprite[] themeSprites;
    public GameObject[] selectButTexts;

    public GameObject[] themes;

    private Image _image;
    private Animator _anim;
    private bool _goMenu = false;
    private float _timeToGo;
    private GameObject _currentShopTheme;

    private void Awake()
    {
        SetShopTheme();
    }
    
    private void Start () 
    {
        _anim = GetComponent<Animator>();
        StartSprites();

        switch(PlayerPrefs.GetInt("CurrentChar"))
        {
            case 0:
                SetButColor(2); // потому что фермер 3 в массиве кнопок и я все запутал
                break;

            case 1:
                SetButColor(0); 
                break;

            case 2:
                SetButColor(1);
                break;
        }
    }
    
	private void Update () 
    {
            
        if (_goMenu && Time.time >= _timeToGo)
            SceneManager.LoadScene("MainMenu");
    }

    public void GoMainMenu()
    {
        _anim.SetTrigger("GoMenu");
        _goMenu = true;
        _timeToGo = Time.time + 0.3f;
    }

    public void SelectFarmer()
    {
        PlayerPrefs.SetInt("CurrentChar", 0);
        SetButColor(2);
    }

    public void SelectKate() // стоимость 500
    {
        if (PlayerPrefs.GetInt("KateIsAv") == 1)
        {
            SetButColor(0);
            PlayerPrefs.SetInt("CurrentChar", 1);
        }

        else if (PlayerPrefs.GetInt("Coins") >= 500)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500);
            PlayerPrefs.SetInt("KateIsAv", 1);
            PlayerPrefs.SetInt("CurrentChar", 1);
            SetButColor(0);
        }
        StartSprites();
    }

    public void SelectMrF() // стоимость 1000
    {
        if (PlayerPrefs.GetInt("MrIsAv") == 1)
        {
            SetButColor(1);
            PlayerPrefs.SetInt("CurrentChar", 2);
        }

        else if (PlayerPrefs.GetInt("Coins") >= 1000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("MrIsAv", 1);
            PlayerPrefs.SetInt("CurrentChar", 2);
            SetButColor(1);
        }
        StartSprites();
    }

    public void SelectFarm()
    {
        if (PlayerPrefs.GetInt("CurrentTheme") == 0) return;
        
        Destroy(_currentShopTheme);
        PlayerPrefs.SetInt("CurrentTheme", 0);
        SetShopTheme();
    }

    public void SelectCity() // стоимость 3000
    {
        if(PlayerPrefs.GetInt("CityIsAv") == 1)
        {
            if(PlayerPrefs.GetInt("CurrentTheme") != 1)
            {
                Destroy(_currentShopTheme);
                PlayerPrefs.SetInt("CurrentTheme", 1);
                SetShopTheme();
            }
        }

        else if(PlayerPrefs.GetInt("Coins") >= 3000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 3000);
            PlayerPrefs.SetInt("CityIsAv", 1);
            Destroy(_currentShopTheme);
            PlayerPrefs.SetInt("CurrentTheme", 1);
            SetShopTheme();
        }
        StartSprites();
    }

    public void SelectBeach() // стоимость 1500
    {
        if (PlayerPrefs.GetInt("BeachIsAv") == 1)
        {
            if (PlayerPrefs.GetInt("CurrentTheme") != 2)
            {
                Destroy(_currentShopTheme);
                PlayerPrefs.SetInt("CurrentTheme", 2);
                SetShopTheme();
            }
        }

        else if (PlayerPrefs.GetInt("Coins") >= 1500)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1500);
            PlayerPrefs.SetInt("BeachIsAv", 1);
            Destroy(_currentShopTheme);
            PlayerPrefs.SetInt("CurrentTheme", 2);
            SetShopTheme();
        }
        StartSprites();
    }

    private void ChangeSprites(int isAvailable, int curChar) // мдааа, найс оффсеты
    {
        _image = charactersBut[curChar].GetComponent<Image>();

        var spriteOffset = curChar; // смещение + 1 к номер перса, так по два спрайта на каждого

        if (isAvailable != 1)
            _image.sprite = sprites[curChar + spriteOffset];

        else
            _image.sprite = sprites[curChar + 1 + spriteOffset];
    }

    private void StartSprites() // как ты мог такое написать вообще, эта функция показывает доступность персов
    {
        ChangeSprites(PlayerPrefs.GetInt("KateIsAv"), 0);
        ChangeSprites(PlayerPrefs.GetInt("MrIsAv"), 1);
        ChangeThemeSprites(PlayerPrefs.GetInt("CityIsAv"), 0);
        ChangeThemeSprites(PlayerPrefs.GetInt("BeachIsAv"), 1);
    }

    private void ChangeThemeSprites(int isAvailable, int curTheme) // мдааа, найс оффсеты
    {
        _image = themeButton[curTheme].GetComponent<Image>();

        var spriteOffset = curTheme;

        if (isAvailable != 1)
            _image.sprite = themeSprites[curTheme + spriteOffset];

        else
        {
            _image.sprite = themeSprites[curTheme + 1 + spriteOffset];
            selectButTexts[curTheme].SetActive(true); // текст
        }
    }

    private void SetShopTheme()
    {
        switch (PlayerPrefs.GetInt("CurrentTheme"))
        {
            case 0:
                _currentShopTheme = Instantiate(themes[0], themes[0].transform.position, Quaternion.identity);
                break;

            case 1:
                _currentShopTheme = Instantiate(themes[1], themes[1].transform.position, Quaternion.identity);
                break;

            case 2:
                _currentShopTheme = Instantiate(themes[2], themes[2].transform.position, Quaternion.identity);
                break;
        }
    }

    private void SetButColor(int selectedBut)
    {
        for (var i = 0; i < charactersBut.Length; i++)
        {
            if (i == selectedBut)
                charactersBut[i].GetComponent<Image>().color = butSel;

            else
                charactersBut[i].GetComponent<Image>().color = butNotSel;
        }
    }
}