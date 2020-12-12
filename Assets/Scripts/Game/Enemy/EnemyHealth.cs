using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Game.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 5f;
        public GameObject sheepToDrop;
        public GameObject deathExplosion;
        public GameObject criticalExplosion;
        public Sprite deadSprite;

        private float _curHealth;
        private EnemyBehaviour _enemyBehaviour;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private BoxCollider2D _collider;
        private bool _criticalDeath = false;

        private void Start()
        {
            _curHealth = maxHealth;
            _enemyBehaviour = GetComponent<EnemyBehaviour>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }
        
        private void Update()
        {
            if (_curHealth <= 0 && _enemyBehaviour.curState != EnemyStates.Dead)
            {
                _animator.SetTrigger("EnemyDie");
                //var isEnemyCarryingSheep = _enemyBehaviour.IsCurrentStateCarrySheep();
                //StartCoroutine(WaitBeforeDie(isEnemyCarryingSheep));
                _enemyBehaviour.SwitchState(EnemyStates.Dead);
                _spriteRenderer.sprite = deadSprite;
                EnemySpawner.deadEnemiesCounter++;
                _collider.enabled = false;
                Debug.LogError(EnemySpawner.deadEnemiesCounter);
            }
            else if(_enemyBehaviour.curState == EnemyStates.Dead && GameManager.gameState == GameStates.Break)
            {
                var isEnemyCarryingSheep = _enemyBehaviour.curState == EnemyStates.CarrySheep;
                Die(isEnemyCarryingSheep);
            }
        }

        public void GetDamage(float damage, bool isCriticalShot)
        {
            if(isCriticalShot)
            {
                _criticalDeath = true;
                var isEnemyCarryingSheep = _enemyBehaviour.curState == EnemyStates.CarrySheep;
                EnemySpawner.deadEnemiesCounter++;
                Die(isEnemyCarryingSheep);
            }
            else
            {
                //_animator.SetTrigger("EnemyGetDamage");
                _curHealth -= damage;
                _spriteRenderer.color = Color.red;
                //EditorApplication.isPaused = true;
                StartCoroutine(StopHitFlash());
            }
        }

        private IEnumerator WaitBeforeDie(bool dropSheep)
        {
            yield return new WaitForSeconds(0.33f);
            Die(dropSheep);
        }
        
        private IEnumerator StopHitFlash()
        {
            yield return new WaitForSeconds(0.05f);
            _spriteRenderer.color = Color.white;
        }

        private void Die(bool dropSheep)
        {
            if(dropSheep)
                Instantiate(sheepToDrop, transform.position, Quaternion.identity);
            
            if(_criticalDeath)
                Instantiate(criticalExplosion, transform.position, Quaternion.identity);
            else
                Instantiate(deathExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
