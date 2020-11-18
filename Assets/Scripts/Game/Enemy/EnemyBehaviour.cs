using UnityEngine;

namespace Game.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public float movementSpeed = 3.0f;
        public Transform targetTransform; // TODO: Переделать в приват и сделать поиск ближайшей из списка

        private int _moveDir = 1;

        private void Start()
        {
            var sheepObjects = GameObject.FindGameObjectsWithTag("Sheep");
            if (sheepObjects.Length > 0)
                targetTransform = sheepObjects[0].transform; // TODO: Соответственно тут выбор не первой, а ближайшей
            else
                targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        private void Update()
        {
            if(!targetTransform)
                targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _moveDir = targetTransform.position.x > transform.position.x ? 1 : -1;
            transform.Translate(Vector3.right * (_moveDir * movementSpeed * Time.deltaTime));
        }
    }
}
