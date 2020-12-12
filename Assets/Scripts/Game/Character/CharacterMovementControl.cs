using System;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovementControl : MonoBehaviour 
    {
        public Animator anim;
        public float movementSpeed = 3f;
        public float movementDirHorizontal = 1f;
        public float movementDirVertival = 1f;

        private SpriteRenderer _sprite;
        private Rigidbody2D _rigidbody;

#if UNITY_ANDROID
        private float screenWidth;
        private bool touchLock = false; // чтобы считывать только одно касание
# endif

        private void Start()
        {
#if UNITY_ANDROID
            screenWidth = Screen.width;
# endif
            _sprite = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update () 
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            movementDirHorizontal = Input.GetAxis("Horizontal");
            movementDirVertival = Input.GetAxis("Vertical");

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
#elif UNITY_ANDROID
            anim.SetBool("IsRunning", true);

            if(Input.touchCount == 0)
                touchLock = false;
            else if (Input.touchCount > 0 && touchLock == false)
            {
                movement *=-1;
                touchLock = true;
            }

            if (movement < 0)
                    sprite.flipX = true;
                else
                    sprite.flipX = false;
            
            /*
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x > screenWidth / 2)
                {
                    sprite.flipX = false;
                    movement = 1f;
                }
                else if (Input.GetTouch(0).position.x < screenWidth / 2)
                {
                    sprite.flipX = true;
                    movement = -1f;
                }

                anim.SetBool("IsRunning", true);
            }
            else
            {
                movement = 0f;
                anim.SetBool("IsRunning", false);
            }
            */
#endif
            transform.Translate(Vector3.right * (movementDirHorizontal * movementSpeed * Time.deltaTime));
            transform.Translate(Vector3.up * (movementDirVertival * movementSpeed * Time.deltaTime));
        }

        private void RevertMovement()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.LogError(other.transform.name);
        }
    }
}
