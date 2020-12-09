using Game.Enemy;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        public float damage = 1f;
        public float criticalChance = 0.5f;
        public float moveSpeed = 20.0f;
    
        private void Update()
        {
            transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Cleaner")) return;

            var isCriticalShot = Random.Range(0f, 1f) < criticalChance;
            var otherHealth = other.GetComponent<EnemyHealth>();
            if(otherHealth)
                otherHealth.GetDamage(damage, isCriticalShot);
            Destroy(gameObject);
        }
    }
}
