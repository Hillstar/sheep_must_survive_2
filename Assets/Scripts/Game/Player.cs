using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator anim;
    public float speed = 3f;
    public float movement = 1f;

    private SpriteRenderer sprite;
    private float screenWidth;

    private bool touchLock = false; // чтобы считывать только одно касание

    private void Start()
    {
        screenWidth = Screen.width;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

        if ((transform.position.x >= 27f && movement > 0) || (transform.position.x <= -29.5f && movement < 0))
            movement *= -1;

#if UNITY_EDITOR || UNITY_STANDALONE

            //for PC
            /*
            movement = Input.GetAxis("Horizontal");

            if (movement != 0)
            {
                if (movement < 0)
                    sprite.flipX = true;

                else
                    sprite.flipX = false;

                anim.SetBool("IsRunning", true);
            }

            else
                anim.SetBool("IsRunning", false);
                */

            if (Input.GetMouseButtonDown(0))
            movement *=-1;
        
            if (movement < 0)
                sprite.flipX = true;

            else
                sprite.flipX = false;

            anim.SetBool("IsRunning", true);

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
