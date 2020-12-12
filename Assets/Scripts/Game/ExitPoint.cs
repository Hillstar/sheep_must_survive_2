using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using Game.Enemy;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.GetComponent<EnemyBehaviour>().curState == EnemyStates.CarrySheep)
        {
            Destroy(other.gameObject);
            GameManager.numSheep--;
        }

        Debug.LogWarning("Exit Point triggered");
    }
}
