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

        private void Update()
        {
            if (GameManager.gameState == GameStates.WaveEnded)
            {
                GameManager.gameState = GameStates.Break;
                canvasAnimator.SetTrigger("BreakStart");
            }
        }

        public void UpgradeDamage()
        {
            characterWeaponControl.curWeapon.damage += 1f;
        }
    
        public void UpgradeShootingSpeed()
        {
            characterWeaponControl.shootingDelay *= 0.8f;
        }
    
        public void SelectPistol()
        {
            characterWeaponControl.SelectWeapon(WeaponTypes.Pistol);
        }
    
        public void SelectShotgun()
        {
            characterWeaponControl.SelectWeapon(WeaponTypes.Shotgun);
        }

        public void GoNextWave()
        {
            canvasAnimator.SetTrigger("BreakStop");
            GameManager.gameState = GameStates.BreakEnded;
        }
    }
}
