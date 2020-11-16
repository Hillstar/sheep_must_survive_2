using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float moveSpeed = 20.0f;

    // Update is called once per frame
    private void Update()
    {
        transform.
        transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cleaner")) return;
        
        var otherHealth = other.GetComponent<CharacterHealth>();
        if(otherHealth)
            otherHealth.GetDamage(damage);
        
        Destroy(gameObject);
    }
}
