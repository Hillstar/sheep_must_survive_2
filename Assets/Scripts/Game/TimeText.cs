using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    public Text scoreText;
    public Text GameOverScoreText;
    public Text GameOverTopText;

    // Update is called once per frame
    void Update () {

        scoreText.text = "" + GameManager.score;
        GameOverScoreText.text = "" + GameManager.score;
        GameOverTopText.text = "" + PlayerPrefs.GetInt("HighScore");
    }
}
