using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FirstScreenManager : MonoBehaviour {

    float timer;
    float mainTimer;
    bool goMenu = false;
    Animator anim;

    private void Awake()
    {
        Application.targetFrameRate = 60; // ставим 60 fps
    }

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        mainTimer = Time.time + 1.5f;
	}
	
	// Update is called once per frame
	void Update () {

        if (goMenu && Time.time >= timer)
            SceneManager.LoadScene("MainMenu");

        else if ((Time.time >= mainTimer || Input.touchCount > 0) && !goMenu)
            GoMainMenu();
	}

    public void GoMainMenu()
    {
        anim.SetTrigger("GoMenu");
        goMenu = true;
        timer = Time.time + 0.4f;
    }
}
