using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    public class CharacterHealth : MonoBehaviour
    {
        public float maxHealth = 10f;
        public float curHealth = 10f;

        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            curHealth = maxHealth;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (curHealth <= 0)
                GameManager.isPlayerAlive = false;
        }

        public void GetDamage(float damage)
        {
            curHealth -= damage;
            _spriteRenderer.color = Color.red;
            StartCoroutine(StopHitFlash());
        }
        
        private IEnumerator StopHitFlash()
        {
            yield return new WaitForSeconds(0.05f);
            _spriteRenderer.color = Color.white;
        }
    }
}
