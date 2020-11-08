using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScreenManager : MonoBehaviour {

    private float _timer;
    private float _mainTimer;
    private bool _goMenu = false;
    private Animator _anim;

    private void Awake()
    {
        Application.targetFrameRate = 60; // ставим 60 fps
    }

    // Use this for initialization
    private void Start ()
    {
        _anim = GetComponent<Animator>();
        _mainTimer = Time.time + 1.5f;
	}
	
	// Update is called once per frame
	private void Update ()
    {

        if (_goMenu && Time.time >= _timer)
            SceneManager.LoadScene("MainMenu");

        else if ((Time.time >= _mainTimer || Input.touchCount > 0) && !_goMenu)
            GoMainMenu();
	}

    public void GoMainMenu()
    {
        _anim.SetTrigger("GoMenu");
        _goMenu = true;
        _timer = Time.time + 0.4f;
    }
}
