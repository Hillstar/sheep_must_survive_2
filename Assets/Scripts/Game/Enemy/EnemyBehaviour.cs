using System;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private enum States
        {
            ChaseSheep,
            ChasePlayer,
            CarrySheep,
            Dead
        }
        
        private States _curState;
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
            //_sheepObjects = GameObject.FindGameObjectsWithTag("Sheep");
        }
        
        private void Update()
        {
            if (_curState == States.Dead)
            {
                _enemyMovement.SetTarget(null);
                return;
            }
            
            // Targeting
            if (!_targetTransform && _curState != States.CarrySheep)
            {
                if (GameManager.sheeps.Length > 0)
                    SwitchState(States.ChaseSheep);
                else
                    SwitchState(States.ChasePlayer);
            }

            // Set target to move
            _enemyMovement.SetTarget(_targetTransform);
        }

        private void SwitchState(States newState)
        {
            _curState = newState;
            
            // Finite-state machine
            switch (_curState)
            {
                case States.ChasePlayer:
                    _targetTransform = _playerObject.transform;
                    break;
                
                case States.ChaseSheep:
                    _targetTransform = FindNearestObject(GameManager.sheeps);
                    break;
                
                case States.CarrySheep:
                    _targetTransform = FindNearestObject(_exitPoints);
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
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = obj.transform;
                }
            }
            return nearestObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Sheep") 
                && _curState != States.CarrySheep && _curState != States.Dead)
            {
                SwitchState(States.CarrySheep);
                Destroy(other.gameObject);
                //Debug.LogError(_curState);
            }
        }

        public bool IsCurrentStateCarrySheep()
        {
            return _curState == States.CarrySheep;
        }

        public void SetDeadState()
        {
            _curState = States.Dead;
        }
    }
}
