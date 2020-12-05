using Game.Enemy;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        public float damage = 1f;
        public float moveSpeed = 20.0f;
    
        private void Update()
        {
            transform.
                transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Cleaner")) return;
        
            var otherHealth = other.GetComponent<EnemyHealth>();
            if(otherHealth)
                otherHealth.GetDamage(damage);
        
            Destroy(gameObject);
        }
    }
}
