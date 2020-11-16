using UnityEngine;

namespace Character
{
    public class CharacterHealth : MonoBehaviour
    {
        public float maxHealth = 10f;

        private float _curHealth = 10f;
        
        private void Start()
        {
            _curHealth = maxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
            if(_curHealth <= 0)
                Destroy(gameObject);
        }

        public void GetDamage(float damage)
        {
            _curHealth -= damage;
        }
    }
}
