using UnityEngine;

namespace Character
{
    public class CharacterMovementControl : MonoBehaviour 
    {
        public Animator anim;
        public float speed = 3f;
        public float movement = 1f;

        private SpriteRenderer _sprite;
    
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
        }

        // Update is called once per frame
        private void Update () 
        {
            if ((transform.position.x >= 27f && movement > 0) || (transform.position.x <= -29.5f && movement < 0))
                movement *= -1;

#if UNITY_EDITOR || UNITY_STANDALONE
        
            movement = Input.GetAxis("Horizontal");

            if (movement != 0)
            {
                if (movement < 0)
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
            //Vector2 newVec = new Vector2(movement * speed * Time.deltaTime, transform.position.y);
            transform.position = new Vector3(transform.position.x + movement * speed * Time.deltaTime, transform.position.y, transform.position.z);
            //transform.Translate(newVec, Space.World);
        }
    }
}
