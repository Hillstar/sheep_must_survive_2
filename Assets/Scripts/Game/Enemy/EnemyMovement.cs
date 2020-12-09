using System;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float movementSpeed = 3.0f;
        
        private int _moveDir = 1;
        private Transform _targetTransform;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(!_targetTransform)
                return;
            // Move
            _moveDir = _targetTransform.position.x > transform.position.x ? 1 : -1;

            var moveVec = _targetTransform.position - transform.position;
            transform.Translate(moveVec.normalized * (movementSpeed * Time.deltaTime));
            
            //Move(_moveDir);
            
            // Flip sprite
            _spriteRenderer.flipX = _moveDir != 1;
        }

        public void SetTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }

        public virtual void Move(int dir)
        {}
    }
}
