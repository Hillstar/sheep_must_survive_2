using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.money++;
            GameManager.hereSheep = false;
            Destroy(gameObject);
        }
    }

    public void Bleat()
    {
        _audioSource.Play();
    }
}
