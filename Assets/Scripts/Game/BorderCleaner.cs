using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCleaner : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Bullet") || other.CompareTag("Clouds"))
            Destroy(other.gameObject);
    }
}
