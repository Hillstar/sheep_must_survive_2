﻿using TMPro;
using UnityEngine;

namespace Game.GameUI
{
    public class GameTexts : MonoBehaviour 
    {
        public TextMeshProUGUI moneyText;
        public TextMeshProUGUI gameOverScoreText;
        public TextMeshProUGUI gameOverTopText;
        public TextMeshProUGUI numSheepText;

        // Update is called once per frame
        private void Update () 
        {
            moneyText.text = GameManager.money.ToString();
            numSheepText.text = "Sheep remaining: " + GameManager.numSheep;
            
            //gameOverScoreText.text = "Score: " + GameManager.score;
            gameOverTopText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
        }
    }
}