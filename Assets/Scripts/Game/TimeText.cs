using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverScoreText;
    public TextMeshProUGUI GameOverTopText;

    // Update is called once per frame
    void Update () {

        scoreText.text = "Score: " + GameManager.score;
        GameOverScoreText.text = "Score: " + GameManager.score;
        GameOverTopText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
    }
}
