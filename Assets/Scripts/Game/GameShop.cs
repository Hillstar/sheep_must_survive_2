using System;
using Game;
using Game.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    public class GameShop : MonoBehaviour
    {
        public CharacterWeaponControl characterWeaponControl;
        public Animator canvasAnimator;
        public GameObject shotgunPrice;
        public GameObject riflePrice;
        public GameObject laserPrice;
        
        private bool _shotgunBought = false;

        private void Update()
        {
            if (GameManager.gameState != GameStates.WaveEnded) return;
            GameManager.gameState = GameStates.Break;
            canvasAnimator.SetTrigger("BreakStart");
        }

        public void UpgradeDamage()
        {
            if (GameManager.money < 100) return;
            GameManager.money -= 100;
            characterWeaponControl.curWeapon.damage += 0.7f;
        }
    
        public void UpgradeShootingSpeed()
        {
            if (GameManager.money < 100) return;
            GameManager.money -= 100;
            characterWeaponControl.curWeapon.shootingDelay *= 0.8f;
        }
    
        public void SelectPistol()
        {
            characterWeaponControl.SelectWeapon(WeaponTypes.Pistol);
        }
    
        public void SelectShotgun()
        {
            if (!_shotgunBought && GameManager.money >= 1000)
            {
                _shotgunBought = true;
                GameManager.money -= 1000;
                shotgunPrice.gameObject.SetActive(false);
            }
            
            if(_shotgunBought)
                characterWeaponControl.SelectWeapon(WeaponTypes.Shotgun);
        }
        
        public void SelectRifle()
        {
            if (!_shotgunBought && GameManager.money >= 2000)
            {
                _shotgunBought = true;
                GameManager.money -= 2000;
                riflePrice.gameObject.SetActive(false);
            }
            
            if(_shotgunBought)
                characterWeaponControl.SelectWeapon(WeaponTypes.Rifle);
        }
        
        public void SelectLaser()
        {
            if (!_shotgunBought && GameManager.money >= 3000)
            {
                _shotgunBought = true;
                GameManager.money -= 3000;
                laserPrice.gameObject.SetActive(false);
            }
            
            if(_shotgunBought)
                characterWeaponControl.SelectWeapon(WeaponTypes.Laser);
        }

        public void GoNextWave()
        {
            canvasAnimator.SetTrigger("BreakStop");
            GameManager.gameState = GameStates.BreakEnded;
        }
    }
}
