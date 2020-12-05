using UnityEngine;

namespace Game.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 5f;
        public GameObject sheepToDrop;

        private float _curHealth;
        private EnemyBehaviour _enemyBehaviour;
        
        private void Start()
        {
            _curHealth = maxHealth;
            _enemyBehaviour = GetComponent<EnemyBehaviour>();
        }
        
        private void Update()
        {
            if (_curHealth <= 0)
            {
                if (_enemyBehaviour.IsCurrentStateCarrySheep())
                    Instantiate(sheepToDrop, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        public void GetDamage(float damage)
        {
            _curHealth -= damage;
        }
    }
}
