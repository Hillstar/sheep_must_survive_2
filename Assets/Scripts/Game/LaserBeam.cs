using System;
using System.Collections;
using System.Collections.Generic;
using Game.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class LaserBeam : MonoBehaviour
    {
        public float damage = 1f;
        public float criticalChance = 0.5f;

        private void Start()
        {
            StartCoroutine(WaitBeforeDeath());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var isCriticalShot = Random.Range(0f, 1f) < criticalChance;
            var otherHealth = other.GetComponent<EnemyHealth>();
            if (otherHealth)
                otherHealth.GetDamage(damage, isCriticalShot);
        }
        
        private IEnumerator WaitBeforeDeath()
        {
            yield return new WaitForSeconds(0.15f);
            Destroy(gameObject);
        }
    }
}