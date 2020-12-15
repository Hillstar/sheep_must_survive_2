using System;
using Game.Character;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public float damage = 1f;
        public float attackDelay = 1.0f;
        public EnemyBehaviour enemyBehaviour;

        private float _timeToAttack;
        public GameObject _target;
        private Animator _animator;
        private AudioSource _audioSource;

        private void Start()
        {
            _animator = enemyBehaviour.gameObject.GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (_target != null)
            {
                if (enemyBehaviour.curState == EnemyStates.ChasePlayer)
                {
                    enemyBehaviour.SwitchState(EnemyStates.Attacking);
                }
                else if (enemyBehaviour.curState == EnemyStates.Attacking)
                {
                    if(Time.time >= _timeToAttack)
                    {
                        var attackAnimationIndex = Random.Range(0, 2);
                        _animator.SetTrigger($"attack_{attackAnimationIndex}");
                        _target.GetComponent<CharacterHealth>().GetDamage(damage);
                        _timeToAttack = Time.time + attackDelay;
                        _audioSource.Play();
                    }
                }
            }
            else if(enemyBehaviour.curState == EnemyStates.Attacking)
            {
                enemyBehaviour.SwitchState(EnemyStates.ChaseSheep);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _target = other.gameObject; 
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _target = null;
            }
        }
    }
}
