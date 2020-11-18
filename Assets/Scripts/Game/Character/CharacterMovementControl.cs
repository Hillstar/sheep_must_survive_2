using System;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovementControl : MonoBehaviour 
    {
        public Animator anim;
        public float movementSpeed = 3f;
        public float movementDir = 1f;
        public float jumpForce = 100.0f;

        private SpriteRenderer _sprite;
        private Rigidbody2D _rigidbody;
        private bool _isGrounded = true;

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

        // Update is called once per frame
        private void Update () 
        {
#if UNITY_EDITOR || UNITY_STANDALONE

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * jumpForce);
                _isGrounded = false;
                Debug.Log("JUMP");
            }
            
            movementDir = Input.GetAxis("Horizontal");

            if (movementDir != 0)
            {
                if (movementDir < 0)
                    _sprite.flipX = true;
                else
                    _sprite.flipX = false;

                anim.SetBool("IsRunning", true);
            }
            else
                anim.SetBool("IsRunning", false);
            
            /* // OLD MOVE CONTROL
            if (Input.GetMouseButtonDown(0))
            movement *=-1;
        
            if (movement < 0)
                sprite.flipX = true;

            else
                sprite.flipX = false;

            anim.SetBool("IsRunning", true);
            */ //~OLD MOVE CONTROL

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
            transform.Translate(Vector3.right * (movementDir * movementSpeed * Time.deltaTime));
            //Vector2 newVec = new Vector2(movement * speed * Time.deltaTime, transform.position.y);
            //transform.position = new Vector3(transform.position.x + movementDir * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z); // Было под андроид
            //transform.Translate(newVec, Space.World);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor"))
                _isGrounded = true;
        }
    }
}
