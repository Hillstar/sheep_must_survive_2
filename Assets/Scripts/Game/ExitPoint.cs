using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            GameManager.numSheep--;
        }

        Debug.LogWarning("Exit Point triggered");
    }
}
