using System;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float movementSpeedMax = 3.0f;
        
        private int _moveDir = 1;
        private Transform _targetTransform;
        private SpriteRenderer _spriteRenderer;
        private EnemyBehaviour _enemyBehaviour;
        private float _slowness = 0.7f;
        protected float movementSpeed;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _enemyBehaviour = GetComponent<EnemyBehaviour>();

            movementSpeed = movementSpeedMax;
        }

        private void Update()
        {
            if(!_targetTransform)
                return;
            
            if (_enemyBehaviour.curState == EnemyStates.CarrySheep)
                movementSpeed = movementSpeedMax * _slowness;
            else
                movementSpeed = movementSpeedMax;
            
            // Move
            var moveVec = _targetTransform.position - transform.position;
            transform.Translate(moveVec.normalized * (movementSpeed * Time.deltaTime));

            // Flip sprite
            _moveDir = _targetTransform.position.x > transform.position.x ? 1 : -1;
            _spriteRenderer.flipX = _moveDir != 1;
        }

        public void SetTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }
    }
}
