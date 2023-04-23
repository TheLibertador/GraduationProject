using System;
using UnityEngine;

namespace Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 20f;
        [SerializeField] private float destroyDistance = 50f;
        [SerializeField] private float damage = 5f;
        
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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (other.gameObject.TryGetComponent<FastTroll>(out FastTroll enemyFastTroll))
                {
                    enemyFastTroll.m_Health -= damage;
                    if (enemyFastTroll.m_Health <= 0)
                    {
                        Destroy(enemyFastTroll.gameObject);
                        GameManager.Instance.numberOfActiveEnemies--;
                        UIManager.Instance.EarnXp(2);
                        ResourceManager.Instance.AddResource("gold",10);
                    }
                    Destroy(gameObject);
                }
                else if (other.gameObject.TryGetComponent<EarlTroll>(out EarlTroll enemyEarlTroll))
                {
                    enemyEarlTroll.m_Health -= damage;
                    if (enemyEarlTroll.m_Health <= 0)
                    {
                        Destroy(enemyEarlTroll.gameObject);
                        GameManager.Instance.numberOfActiveEnemies--;
                        UIManager.Instance.EarnXp(5);
                        ResourceManager.Instance.AddResource("gold",30);
                    }
                    Destroy(gameObject);
                }
                else if (other.gameObject.TryGetComponent<HeavyTroll>(out HeavyTroll enemyHeavyTroll))
                {
                    enemyHeavyTroll.m_Health -= damage;
                    if (enemyHeavyTroll.m_Health <= 0)
                    {
                        Destroy(enemyHeavyTroll.gameObject);
                        GameManager.Instance.numberOfActiveEnemies--;
                        UIManager.Instance.EarnXp(5);
                        ResourceManager.Instance.AddResource("gold",20);
                    }
                    Destroy(gameObject);
                }
                else if (other.gameObject.TryGetComponent<KingTroll>(out KingTroll enemyKingTroll))
                {
                    enemyKingTroll.m_Health -= damage;
                    if (enemyKingTroll.m_Health <= 0)
                    {
                        Destroy(enemyKingTroll.gameObject);
                        GameManager.Instance.numberOfActiveEnemies--;
                        UIManager.Instance.EarnXp(10);
                        ResourceManager.Instance.AddResource("gold",50);
                    }
                    Destroy(gameObject);
                }
                else if (other.gameObject.TryGetComponent<SmallTroll>(out SmallTroll enemySmallTroll))
                {
                    enemySmallTroll.m_Health -= damage;
                    if (enemySmallTroll.m_Health <= 0)
                    {
                        Destroy(enemySmallTroll.gameObject);
                        GameManager.Instance.numberOfActiveEnemies--;
                        UIManager.Instance.EarnXp(1);
                        ResourceManager.Instance.AddResource("gold",5);
                    }
                    Destroy(gameObject);
                }
            }
            else if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Rock"))
            {
                Destroy(gameObject);
            }
        }

    }
}