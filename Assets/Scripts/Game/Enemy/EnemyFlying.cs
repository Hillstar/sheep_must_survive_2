using UnityEngine;

namespace Game.Enemy
{
    public class EnemyFlying : EnemyMovement
    {
        public override void Move(int dir)
        {
            transform.Translate(Vector3.right * (dir * movementSpeed * Time.deltaTime));
        }

        private void Charge()
        {
            
        }
    }
}
