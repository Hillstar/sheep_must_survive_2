using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public Color ButSel;
    public Color ButNotSel;

    public Button[] charactersBut;
    public Button[] themeButton;
    public Sprite[] sprites; //первые два Кейт(1 недоступен, 2 доступен) и тд
    public Sprite[] themeSprites;
    public GameObject[] SelectButTexts;

    public GameObject[] themes;

    Image image;
    Animator anim;
    bool goMenu = false;
    float timeToGo;
    GameObject currentShopTheme;

    private void Awake()
    {
        SetShopTheme();
    }

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
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
	
	// Update is called once per frame
	void Update () {
            
        if (goMenu && Time.time >= timeToGo)
            SceneManager.LoadScene("MainMenu");
    }

    public void GoMainMenu()
    {
        anim.SetTrigger("GoMenu");
        goMenu = true;
        timeToGo = Time.time + 0.3f;
    }

    public void SelectFarmer()
    {
        PlayerPrefs.SetInt("CurrentChar", 0);
        SetButColor(2);
    }

    public void SelectKate() //стоимость 500
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

    public void SelectMrF() //стоимость 1000
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
        if(PlayerPrefs.GetInt("CurrentTheme") != 0)
        {
            Destroy(currentShopTheme);
            PlayerPrefs.SetInt("CurrentTheme", 0);
            SetShopTheme();
        }
    }

    public void SelectCity() //стоимость 3000
    {
        if(PlayerPrefs.GetInt("CityIsAv") == 1)
        {
            if(PlayerPrefs.GetInt("CurrentTheme") != 1)
            {
                Destroy(currentShopTheme);
                PlayerPrefs.SetInt("CurrentTheme", 1);
                SetShopTheme();
            }
        }

        else if(PlayerPrefs.GetInt("Coins") >= 3000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 3000);
            PlayerPrefs.SetInt("CityIsAv", 1);
            Destroy(currentShopTheme);
            PlayerPrefs.SetInt("CurrentTheme", 1);
            SetShopTheme();
        }
        StartSprites();
    }

    public void SelectBeach() //стоимость 1500
    {
        if (PlayerPrefs.GetInt("BeachIsAv") == 1)
        {
            if (PlayerPrefs.GetInt("CurrentTheme") != 2)
            {
                Destroy(currentShopTheme);
                PlayerPrefs.SetInt("CurrentTheme", 2);
                SetShopTheme();
            }
        }

        else if (PlayerPrefs.GetInt("Coins") >= 1500)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1500);
            PlayerPrefs.SetInt("BeachIsAv", 1);
            Destroy(currentShopTheme);
            PlayerPrefs.SetInt("CurrentTheme", 2);
            SetShopTheme();
        }
        StartSprites();
    }

    void ChangeSprites(int isAvailable, int curChar) // мдааа, найс оффсеты
    {
        image = charactersBut[curChar].GetComponent<Image>();

        int spriteOffset = curChar; // смещение + 1 к номер перса, так по два спрайта на каждого

        if (isAvailable != 1)
            image.sprite = sprites[curChar + spriteOffset];

        else
            image.sprite = sprites[curChar + 1 + spriteOffset];
    }

    void StartSprites() // как ты мог такое написать вообще, эта функция показывает доступность персов
    {
        ChangeSprites(PlayerPrefs.GetInt("KateIsAv"), 0);
        ChangeSprites(PlayerPrefs.GetInt("MrIsAv"), 1);
        ChangeThemeSprites(PlayerPrefs.GetInt("CityIsAv"), 0);
        ChangeThemeSprites(PlayerPrefs.GetInt("BeachIsAv"), 1);
    }

    void ChangeThemeSprites(int isAvailable, int curTheme) // мдааа, найс оффсеты
    {
        image = themeButton[curTheme].GetComponent<Image>();

        int spriteOffset = curTheme;

        if (isAvailable != 1)
            image.sprite = themeSprites[curTheme + spriteOffset];

        else
        {
            image.sprite = themeSprites[curTheme + 1 + spriteOffset];
            SelectButTexts[curTheme].SetActive(true); // текст
        }
    }

    void SetShopTheme()
    {
        switch (PlayerPrefs.GetInt("CurrentTheme"))
        {
            case 0:
                currentShopTheme = Instantiate(themes[0], themes[0].transform.position, Quaternion.identity);
                break;

            case 1:
                currentShopTheme = Instantiate(themes[1], themes[1].transform.position, Quaternion.identity);
                break;

            case 2:
                currentShopTheme = Instantiate(themes[2], themes[2].transform.position, Quaternion.identity);
                break;
        }
    }

    void SetButColor(int selectedBut)
    {
        for (int i = 0; i < charactersBut.Length; i++)
        {
            if (i == selectedBut)
                charactersBut[i].GetComponent<Image>().color = ButSel;

            else
                charactersBut[i].GetComponent<Image>().color = ButNotSel;
        }
    }
}