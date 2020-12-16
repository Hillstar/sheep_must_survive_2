using System;
using Game.Character;
using TMPro;
using UnityEngine;

namespace Game.GameUI
{
    public class GameTexts : MonoBehaviour 
    {
        public TextMeshProUGUI moneyText;
        public TextMeshProUGUI gameOverScoreText;
        public TextMeshProUGUI gameOverTopText;
        public TextMeshProUGUI numSheepText;
        public TextMeshProUGUI waveNumText;
        public TextMeshProUGUI hpText;

        private CharacterHealth _characterHealth;
        private EnemySpawner _enemySpawner;

        private void Start()
        {
            _characterHealth = GameObject.FindWithTag("Player").GetComponent<CharacterHealth>();
            _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        }
        
        private void Update () 
        {
            moneyText.text = GameManager.money.ToString();
            numSheepText.text = "Sheep remaining: " + GameManager.numSheep;
            waveNumText.text = _enemySpawner.numWaves.ToString();
            hpText.text = _characterHealth.curHealth.ToString();
            
            //gameOverScoreText.text = "Score: " + GameManager.score;
            gameOverTopText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
        }
    }
}
