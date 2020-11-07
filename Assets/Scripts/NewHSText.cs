using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHSText : MonoBehaviour {

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        if (!GameManager.isPlayerAlive && GameManager.score > PlayerPrefs.GetInt("HighScore"))
            anim.SetTrigger("NewHS");
	}
}
