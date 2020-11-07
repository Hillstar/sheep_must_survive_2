using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int score;
    public static bool hereSheep;
    public static bool isPlayerAlive;
    public static bool isntMute = true;
    public static int gameCounter = 0;

    public GameObject[] characters;

    // Use this for initialization
    void Awake () {

        isPlayerAlive = true;
        score = 0;
        hereSheep = false;
        AudioListener.volume = isntMute ? 1 : 0;

        Vector3 startPos = new Vector3(-14f, -4.12f, 0f);
        Instantiate(characters[PlayerPrefs.GetInt("CurrentChar")], startPos, Quaternion.identity);
    }
}
