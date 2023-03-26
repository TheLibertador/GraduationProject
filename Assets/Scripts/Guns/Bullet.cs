using UnityEngine;

namespace Guns
{
    public class Bullet : MonoBehaviour
    {
        public float moveSpeed = 20f;
        public float destroyDistance = 50f;

        private Vector3 _forwardDirection;
        private Vector3 startingPosition;
        void Start()
        {
            startingPosition = transform.position; // Save starting position
        }
        
        private void Update()
        {
            Quaternion rotation = transform.rotation;

            // Calculate the forward direction based on the rotation
            Vector3 forwardDirection = rotation * Vector3.up;
            
            // Move forward
            transform.position += forwardDirection * moveSpeed * Time.deltaTime;

            // Check if we've reached the specified distance
            float distance = Vector3.Distance(transform.position, startingPosition);

            // Check if distance is less than or equal to the threshold
            if (distance >= destroyDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}