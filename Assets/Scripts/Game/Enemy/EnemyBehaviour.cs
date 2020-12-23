using System;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public EnemyStates curState;
        public bool attackPriority;
        
        private Transform _targetTransform;
        private GameObject[] _exitPoints;
        private GameObject _playerObject;
        //private GameObject[] _sheepObjects;
        //private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private EnemyMovement _enemyMovement;
        
        private void Start()
        {
            //_spriteRenderer = GetComponent<SpriteRenderer>();
            _playerObject = GameObject.FindGameObjectWithTag("Player");
            _exitPoints = GameObject.FindGameObjectsWithTag("EnemyExitPoint");
            _animator = GetComponent<Animator>();
            _enemyMovement = GetComponent<EnemyMovement>();
            if(attackPriority)
                SwitchState(EnemyStates.ChasePlayer);
            else
                SwitchState(EnemyStates.ChaseSheep);
            //_sheepObjects = GameObject.FindGameObjectsWithTag("Sheep");
        }
        
        private void Update()
        {
            if(curState == EnemyStates.Dead || curState == EnemyStates.Attacking)
            {
                _enemyMovement.SetTarget(null);
                return;
            }
            
            // Targeting
            if(!_targetTransform && curState != EnemyStates.CarrySheep)
            {
                if (GameManager.sheeps.Length > 0)
                    SwitchState(EnemyStates.ChaseSheep);
                else
                    SwitchState(EnemyStates.ChasePlayer);
            }

            // Set target to move
            _enemyMovement.SetTarget(_targetTransform);
        }

        public void SwitchState(EnemyStates newState)
        {
            curState = newState;
            
            // Finite-state machine
            switch(curState)
            {
                case EnemyStates.ChasePlayer:
                    _animator.SetBool("Running", true);
                    _targetTransform = _playerObject.transform;
                    break;
                
                case EnemyStates.ChaseSheep:
                    _animator.SetBool("Running", true);
                    _targetTransform = FindNearestObject(GameManager.sheeps);
                    break;
                
                case EnemyStates.CarrySheep:
                    _animator.SetBool("Running", true);
                    _targetTransform = FindNearestObject(_exitPoints);
                    break;
                
                case EnemyStates.Attacking:
                    _animator.SetBool("Running", false);
                    break;
                
                case EnemyStates.Dead:
                    _animator.SetBool("Running", false);
                    break;
            }
        }

        private Transform FindNearestObject(GameObject[] objects)
        {
            Transform nearestObject = null;
            var minDistance = Mathf.Infinity;
            var position = transform.position;

            foreach (var obj in objects)
            {
                var distance = Mathf.Abs(obj.transform.position.x - position.x);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = obj.transform;
                }
            }
            return nearestObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Sheep") && !attackPriority
                && curState != EnemyStates.CarrySheep && curState != EnemyStates.Dead)
            {
                SwitchState(EnemyStates.CarrySheep);
                other.gameObject.GetComponent<Sheep>().Bleat();
                Destroy(other.gameObject);
                //Debug.LogError(_curState);
            }
        }
    }
}
