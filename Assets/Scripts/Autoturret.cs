using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoturret : MonoBehaviour
{ 
    public GameObject bulletPrefab;
    public float shootRange = 5f;   
    public float rotationSpeed = 10f; 
    public float shootInterval = 0.5f;  
    public Transform bulletSpawnPoint;
    [Header("İkincisini koymak zorunlu değil")]
    public Transform bulletSpawnPoint2;
    public GameObject MuzzleFlashParticle;

    private GameObject[] enemies;
    private GameObject currentTarget; 

    private float lastShotTime = 0f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        Transform[] spawnPoints = GetComponentsInChildren<Transform>(true);

        int spawnPointCount = 0;

        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint.name.Equals("SpawnPoint"))
            {
                spawnPointCount++;

                if (spawnPointCount == 1)
                {
                    bulletSpawnPoint = spawnPoint;
                }
                else if (spawnPointCount == 2)
                {
                    bulletSpawnPoint2 = spawnPoint;
                }
            }
        }
    }


    void Update()
    {
        // Find all the GameObjects with "enemy" tag and store them in the enemies array
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            // Find the closest enemy
            float closestDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    currentTarget = enemy;
                }
            }

            // Rotate the turret to face the current target
            Vector3 direction = currentTarget.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            // Check if the current target is within shoot range and enough time has passed since the last shot
            if (closestDistance < shootRange && Time.time > lastShotTime + shootInterval)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
                if (audioSource != null && shootSound != null)
                {
                    audioSource.PlayOneShot(shootSound);
                }
                bullet.transform.Rotate(90, 0, 0); // Adjust the bullet's local rotation to face forward
                Instantiate(MuzzleFlashParticle, bulletSpawnPoint.position, Quaternion.identity, gameObject.transform);

                if (bulletSpawnPoint2 != null)
                {
                    var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint2.position, transform.rotation);
                    bullet2.transform.Rotate(90, 0, 0); // Adjust the bullet's local rotation to face forward
                    Instantiate(MuzzleFlashParticle, bulletSpawnPoint2.position, Quaternion.identity, gameObject.transform);
                }
                lastShotTime = Time.time;
            }
        }
    }
}