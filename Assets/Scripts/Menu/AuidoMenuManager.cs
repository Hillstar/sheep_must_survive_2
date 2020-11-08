using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuidoMenuManager : MonoBehaviour {

    private static bool _audioBegin = false;
    private AudioSource _music;
    private void Awake()
    {
        _music = GetComponent<AudioSource>();

        if (!_audioBegin)
        {
            _music.Play();
            DontDestroyOnLoad(gameObject);
            _audioBegin = true;
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Shop" && SceneManager.GetActiveScene().name != "MainMenu")
        {
            _music.Stop();
            _audioBegin = false;
        }
    }
}
