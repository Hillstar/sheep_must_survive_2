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
            CarrySheep
        }
        
        public float movementSpeed = 3.0f;
        
        private int _moveDir = 1;
        private States _curState;
        private Transform _targetTransform;
        private GameObject[] _exitPoints;
        private GameObject _playerObject;
        //private GameObject[] _sheepObjects;
        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _playerObject = GameObject.FindGameObjectWithTag("Player");
            _exitPoints = GameObject.FindGameObjectsWithTag("EnemyExitPoint");
            //_sheepObjects = GameObject.FindGameObjectsWithTag("Sheep");
        }
        
        private void Update()
        {
            // Targeting
            if (!_targetTransform && _curState != States.CarrySheep)
            {
                if (GameManager.sheeps.Length > 0)
                    SwitchState(States.ChaseSheep);
                else
                    SwitchState(States.ChasePlayer);
            }

            // Movement 
            _moveDir = _targetTransform.position.x > transform.position.x ? 1 : -1;
            transform.Translate(Vector3.right * (_moveDir * movementSpeed * Time.deltaTime));
        }

        private void SwitchState(States newState)
        {
            _curState = newState;
            
            // Finite-state machine
            switch (_curState)
            {
                case States.ChasePlayer:
                    _spriteRenderer.color = Color.red;
                    _targetTransform = _playerObject.transform;
                    break;
                
                case States.ChaseSheep:
                    _spriteRenderer.color = Color.yellow;
                    _targetTransform = FindNearestObject(GameManager.sheeps);
                    break;
                
                case States.CarrySheep:
                    _spriteRenderer.color = Color.magenta;
                    _targetTransform = FindNearestObject(_exitPoints);
                    break;
                
                default:
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
            if (other.gameObject.CompareTag("Sheep") && _curState != States.CarrySheep)
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
    }
}
