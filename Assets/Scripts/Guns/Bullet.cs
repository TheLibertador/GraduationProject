using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 20f;
        [SerializeField] private float destroyDistance = 50f;
        [SerializeField] private int minDamage = 1;
        [SerializeField] private int maxDamage = 10;
        [SerializeField] private GameObject deathParticleEffect;
        [SerializeField] private GameObject textPrefab;
        
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
                var damage = Random.Range(minDamage,maxDamage);
                if (other.gameObject.TryGetComponent<FastTroll>(out FastTroll enemyFastTroll))
                {
                    enemyFastTroll.m_Health -= damage;
                    GameObject textObject = Instantiate(textPrefab, new Vector3(other.transform.position.x, 0.1f, other.transform.position.z), Quaternion.identity);
                    TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
                    textMeshPro.text = "-" + damage.ToString();
                    if (enemyFastTroll.m_Health <= 0)
                    {
                        var particleEffect = Instantiate(deathParticleEffect, other.transform.position, Quaternion.identity);
                        StartCoroutine(DestroyPartilceEffect(particleEffect));
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
                    GameObject textObject = Instantiate(textPrefab, new Vector3(other.transform.position.x, 0.1f, other.transform.position.z), Quaternion.identity);
                    TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
                    textMeshPro.text = "-" + damage.ToString();
                    if (enemyEarlTroll.m_Health <= 0)
                    {
                        var particleEffect = Instantiate(deathParticleEffect, other.transform.position, Quaternion.identity);
                        StartCoroutine(DestroyPartilceEffect(particleEffect));
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
                    GameObject textObject = Instantiate(textPrefab, new Vector3(other.transform.position.x, 0.1f, other.transform.position.z), Quaternion.identity);
                    TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
                    textMeshPro.text = "-" + damage.ToString();
                    if (enemyHeavyTroll.m_Health <= 0)
                    {
                        var particleEffect = Instantiate(deathParticleEffect, other.transform.position, Quaternion.identity);
                        StartCoroutine(DestroyPartilceEffect(particleEffect));
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
                    GameObject textObject = Instantiate(textPrefab, new Vector3(other.transform.position.x, 0.1f, other.transform.position.z), Quaternion.identity);
                    TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
                    textMeshPro.text = "-" + damage.ToString();
                    if (enemyKingTroll.m_Health <= 0)
                    {
                        var particleEffect = Instantiate(deathParticleEffect, other.transform.position, Quaternion.identity);
                        StartCoroutine(DestroyPartilceEffect(particleEffect));
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
                    GameObject textObject = Instantiate(textPrefab, new Vector3(other.transform.position.x, 0.1f, other.transform.position.z), Quaternion.identity);
                    TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
                    textMeshPro.text = "-" + damage.ToString();
                    if (enemySmallTroll.m_Health <= 0)
                    {
                        var particleEffect = Instantiate(deathParticleEffect, other.transform.position, Quaternion.identity);
                        StartCoroutine(DestroyPartilceEffect(particleEffect));
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

        private IEnumerator DestroyPartilceEffect(GameObject particleEffect)
        {
            yield return new WaitForSeconds(1f);
            Destroy(particleEffect);
        }
    }
    
}