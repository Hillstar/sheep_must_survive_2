using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuidoMenuManager : MonoBehaviour {

    static bool AudioBegin = false;
    AudioSource music;
    void Awake()
    {
        music = GetComponent<AudioSource>();

        if (!AudioBegin)
        {
            music.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Shop" && SceneManager.GetActiveScene().name != "MainMenu")
        {
            music.Stop();
            AudioBegin = false;
        }
    }
}
