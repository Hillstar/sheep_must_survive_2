using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public enum ShootingTypes
    {
        Pistol,
        Shotgun
    }

    public float damage = 1f;
    public GameObject bullet;
    public GameObject gunPoint;
    public GameObject gunSprite;
    public ShootingTypes gunType;
    
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _spriteRenderer = gunSprite.GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetSpriteFlipY(bool isEnabled)
    {
        _spriteRenderer.flipY = isEnabled;
    }

    public void Shoot()
    {
        _audioSource.Play();
        GameObject bulletObject;
        switch (gunType)
        {
            case ShootingTypes.Pistol:
                bulletObject = Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                bulletObject.GetComponent<Bullet>().damage = damage;
                break;
            case ShootingTypes.Shotgun:
                for (var i = 0; i < 5; i++)
                {
                    var angleShift = Random.Range(-0.3f, 0.3f);
                    var newRotation = new Quaternion(transform.rotation.x, transform.rotation.x, transform.rotation.z + angleShift, transform.rotation.w);
                    bulletObject = Instantiate(bullet, gunPoint.transform.position, newRotation);
                    bulletObject.GetComponent<Bullet>().damage = damage;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }   
    }
}
