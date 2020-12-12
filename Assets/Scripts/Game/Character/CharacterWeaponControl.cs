using System;
using UnityEngine;

namespace Game.Character
{
    public class CharacterWeaponControl : MonoBehaviour
    {
        public float shootingDelay = 1.0f;
        public GameObject pistolGameObject;
        public GameObject shotgunGameObject;
        
        public Weapon curWeapon;
        
        private float _timeToShoot;

        private void Start()
        {
            pistolGameObject.SetActive(false);
            shotgunGameObject.SetActive(false);
            SelectWeapon(WeaponTypes.Pistol);
        }

        private void Update()
        {
            // Shooting control
            if(Input.GetMouseButton(0) && Time.time >= _timeToShoot)
            {
                curWeapon.Shoot();
                _timeToShoot = Time.time + shootingDelay;
            }
        
            // Weapon rotating
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (Vector2)(mousePos - transform.position).normalized;
            var rotAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotAngle);
            if (rotAngle > 90f || rotAngle < -90f)
                curWeapon.SetSpriteFlipY(true);
            else
                curWeapon.SetSpriteFlipY(false);
        }

        public void SelectWeapon(WeaponTypes weapon)
        {
            if(curWeapon) curWeapon.gameObject.SetActive(false);
            switch (weapon)
            {
                case WeaponTypes.Pistol:
                    Debug.LogWarning("Selected Pistol");
                    pistolGameObject.SetActive(true);
                    curWeapon = pistolGameObject.GetComponent<Weapon>();
                    break;
                case WeaponTypes.Shotgun:
                    Debug.LogWarning("Selected Shotgun");
                    shotgunGameObject.SetActive(true);
                    curWeapon = shotgunGameObject.GetComponent<Weapon>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weapon), weapon, null);
            }
        }
    }
}
