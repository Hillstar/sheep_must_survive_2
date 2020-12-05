using System;
using UnityEngine;

namespace Game.Character
{
    public class CharacterWeaponControl : MonoBehaviour
    {
        public float shootingDelay = 1.0f;
        public GameObject bullet;
        public GameObject gunPoint;

        private float _timeToShoot;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            // Shooting control
            if(Input.GetMouseButton(0) && Time.time >= _timeToShoot)
            {
                Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                _timeToShoot = Time.time + shootingDelay;
                _audioSource.Play();
            }
        
            // Weapon rotating
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (Vector2)(mousePos - transform.position).normalized;
            var rotAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotAngle);
        }
    }
}
