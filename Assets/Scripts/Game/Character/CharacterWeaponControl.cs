using System;
using UnityEngine;

namespace Game.Character
{
    public class CharacterWeaponControl : MonoBehaviour
    {
        public float shootingDelay = 1.0f;
        public Weapon weapon;
        
        private float _timeToShoot;
        
        private void Update()
        {
            // Shooting control
            if(Input.GetMouseButton(0) && Time.time >= _timeToShoot)
            {
                weapon.Shoot();
                _timeToShoot = Time.time + shootingDelay;
            }
        
            // Weapon rotating
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (Vector2)(mousePos - transform.position).normalized;
            var rotAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotAngle);
            if (rotAngle > 90f || rotAngle < -90f)
                weapon.SetSpriteFlipY(true);
            else
                weapon.SetSpriteFlipY(false);
        }
    }
}
