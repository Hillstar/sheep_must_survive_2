using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using TMPro;

public class NumSheepText : MonoBehaviour
{
    private TextMeshProUGUI _numSheepText;

    private void Start()
    {
        _numSheepText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _numSheepText.text = "Sheep remaining: " + GameManager.numSheep;
    }
}
