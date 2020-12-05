using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Sheep : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.score++;
            GameManager.hereSheep = false;
            Destroy(gameObject);
        }
    }
}
