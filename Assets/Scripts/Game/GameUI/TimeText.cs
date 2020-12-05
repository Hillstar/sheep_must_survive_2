using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour 
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverTopText;

    // Update is called once per frame
    private void Update () 
    {
        scoreText.text = "Score: " + GameManager.score;
        gameOverScoreText.text = "Score: " + GameManager.score;
        gameOverTopText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
    }
}
