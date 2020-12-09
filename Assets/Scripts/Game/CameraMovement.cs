using UnityEngine;

namespace Game
{
    public class CameraMovement : MonoBehaviour 
    {
        public GameObject target;
        public float cameraHeight = 3f;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        
        private void Update () 
        {
            if(target != null && transform.position != target.transform.position)
            {
                transform.position = new Vector3(target.transform.position.x, target.transform.position.y + cameraHeight, transform.position.z);
            }
        }
    }
}
