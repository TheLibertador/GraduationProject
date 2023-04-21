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
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(90,0,0));
                Instantiate(MuzzleFlashParticle, bulletSpawnPoint.position, Quaternion.identity, gameObject.transform);
                
                var bulletRotation = bullet.transform.rotation;
                bulletRotation.eulerAngles = new Vector3(bulletRotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, bulletRotation.eulerAngles.z);
                bullet.transform.rotation = bulletRotation;
                
                if (bulletSpawnPoint2!=null)
                {
                    var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint2.position, Quaternion.Euler(90,0,0));
                    Instantiate(MuzzleFlashParticle, bulletSpawnPoint2.position, Quaternion.identity, gameObject.transform);
                    
                    var bulletRotation2 = bullet.transform.rotation;
                    bulletRotation2.eulerAngles = new Vector3(bulletRotation2.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, bulletRotation2.eulerAngles.z);
                    bullet2.transform.rotation = bulletRotation2;
                }
                lastShotTime = Time.time;
            }
        }
    }
}