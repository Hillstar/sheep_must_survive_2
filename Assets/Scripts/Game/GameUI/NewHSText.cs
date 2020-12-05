using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;

public class NewHSText : MonoBehaviour {
    
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update () 
    {
        if (!GameManager.isPlayerAlive && GameManager.score > PlayerPrefs.GetInt("HighScore"))
            _anim.SetTrigger("NewHS");
	}
}
