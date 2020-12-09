using UnityEngine;

namespace Game.Enemy
{
    public class EnemyRunning : EnemyMovement
    {
        public override void Move(int dir)
        {
            transform.Translate(Vector3.right * (dir * movementSpeed * Time.deltaTime));
        }
    }
}
