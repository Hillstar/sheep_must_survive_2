using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        public float damage = 1f;
        public GameObject bullet;
        public GameObject gunPoint;
        public GameObject gunSprite;
        public WeaponTypes gunType;
    
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
                case WeaponTypes.Pistol:
                    bulletObject = Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                    bulletObject.GetComponent<Bullet>().damage = damage;
                    break;
                case WeaponTypes.Shotgun:
                    for (var i = 0; i < 5; i++)
                    {
                        var angleShift = Random.Range(-15f, 15f);
                        bulletObject = Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                        bulletObject.transform.Rotate(0f, 0f, angleShift);
                        bulletObject.GetComponent<Bullet>().damage = damage;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }   
        }
    }
}
