using System;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovementControl : MonoBehaviour 
    {
        public Animator anim;
        public Joystick joystick;
        public float movementSpeed = 3f;
        public float movementDirHorizontal = 1f;
        public float movementDirVertival = 1f;

        private SpriteRenderer _sprite;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update () 
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            movementDirHorizontal = Input.GetAxis("Horizontal");
            movementDirVertival = Input.GetAxis("Vertical");
#elif UNITY_ANDROID
            movementDirHorizontal = joystick.Horizontal;
            movementDirVertival = joystick.Vertical;
#endif
            
            if(movementDirHorizontal != 0 || movementDirVertival != 0)
            {
                if(movementDirHorizontal < 0)
                    _sprite.flipX = true;
                else
                    _sprite.flipX = false;

                anim.SetBool("IsRunning", true);
            }
            else
                anim.SetBool("IsRunning", false);
            
#if UNITY_EDITOR || UNITY_STANDALONE
            transform.Translate(Vector3.right * (movementDirHorizontal * movementSpeed * Time.deltaTime));
            transform.Translate(Vector3.up * (movementDirVertival * movementSpeed * Time.deltaTime));
#elif UNITY_ANDROID
            var moveVector = new Vector2(movementDirHorizontal,movementDirVertival).normalized * movementSpeed;
            transform.Translate(moveVector * Time.deltaTime);
#endif
        }
    }
}
