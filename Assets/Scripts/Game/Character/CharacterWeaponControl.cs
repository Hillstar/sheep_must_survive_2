using System;
using UnityEngine;

namespace Game.Character
{
    public class CharacterWeaponControl : MonoBehaviour
    {
        public Joystick joystick;
        public GameObject pistolGameObject;
        public GameObject shotgunGameObject;
        public GameObject rifleGameObject;
        public GameObject laserGameObject;
        public Weapon curWeapon;
        
        private float _timeToShoot;

        private void Start()
        {
            pistolGameObject.SetActive(false);
            shotgunGameObject.SetActive(false);
            rifleGameObject.SetActive(false);
            laserGameObject.SetActive(false);
            SelectWeapon(WeaponTypes.Laser);
        }

        private void Update()
        {
            // Shooting control
#if UNITY_EDITOR || UNITY_STANDALONE
            if(Input.GetMouseButton(0) && Time.time >= _timeToShoot)
            {
                curWeapon.Shoot();
                _timeToShoot = Time.time + curWeapon.shootingDelay;
            }
            // Weapon rotating
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (Vector2)(mousePos - transform.position).normalized;
#elif UNITY_ANDROID
            var dir = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
            if(dir != Vector2.zero && Time.time >= _timeToShoot)
            {
                curWeapon.Shoot();
                _timeToShoot = Time.time + shootingDelay;
            }
#endif
            
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
                    pistolGameObject.SetActive(true);
                    curWeapon = pistolGameObject.GetComponent<Weapon>();
                    break;
                case WeaponTypes.Shotgun:
                    shotgunGameObject.SetActive(true);
                    curWeapon = shotgunGameObject.GetComponent<Weapon>();
                    break;
                case WeaponTypes.Rifle:
                    rifleGameObject.SetActive(true);
                    curWeapon = rifleGameObject.GetComponent<Weapon>();
                    break;
                case WeaponTypes.Laser:
                    laserGameObject.SetActive(true);
                    curWeapon = laserGameObject.GetComponent<Weapon>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weapon), weapon, null);
            }
        }
    }
}
