using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        public float damage = 1f;
        public float shootingDelay = 1.0f;
        public float criticalChance = 0.5f;
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
                    bulletObject.GetComponent<Bullet>().criticalChance = criticalChance;
                    break;
                case WeaponTypes.Shotgun:
                    for (var i = 0; i < 5; i++)
                    {
                        var angleShift = Random.Range(-15f, 15f);
                        bulletObject = Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                        bulletObject.transform.Rotate(0f, 0f, angleShift);
                        bulletObject.GetComponent<Bullet>().damage = damage;
                        bulletObject.GetComponent<Bullet>().criticalChance = criticalChance;
                    }
                    break;
                case WeaponTypes.Rifle:
                    bulletObject = Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                    bulletObject.GetComponent<Bullet>().damage = damage;
                    bulletObject.GetComponent<Bullet>().criticalChance = criticalChance;
                    bulletObject.GetComponent<Bullet>().moveSpeed *= 1.5f;
                    break;
                case WeaponTypes.Laser:
                    bulletObject = Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                    bulletObject.transform.Rotate(0f, 0f, 90f);
                    bulletObject.GetComponent<LaserBeam>().damage = damage;
                    bulletObject.GetComponent<LaserBeam>().criticalChance = criticalChance;
                    bulletObject.transform.parent = gameObject.transform;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }   
        }
    }
}
