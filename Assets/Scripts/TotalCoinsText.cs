﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinsText : MonoBehaviour {

    public Text totalCoins;
	
	// Update is called once per frame
	private void Update () 
	{

        totalCoins.text = "" + PlayerPrefs.GetInt("Coins");
	}
}
