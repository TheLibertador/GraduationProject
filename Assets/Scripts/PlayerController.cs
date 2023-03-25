using System;
using Unity.Mathematics;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public float speed = 5f;
    public GameObject bulletPrefab;
    public GameObject MuzzleFlashParticle;
    public Transform bulletSpawnPoint;
    public float fireDelay = 0.1f;

    private float _fireTimer;

    private int health = 100;
    
    private Rigidbody m_Rigidbody;
    private Animator m_Animator;
    
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();
        mainCamera = Camera.main;

    }
    private void Start()
    {
        EventManager.OnPlayerTakeDamageEvent += PlayerTakeDamageEvent;
    }

    void Update()
    {
        // Move the player with WASD keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0f, z) * speed * Time.deltaTime;
        if (z + x > 0)
        {
            m_Animator.SetBool("Moving", true);
        }
        else
        {
            m_Animator.SetBool("Moving", false);
        }

        if (Input.GetButton("Fire1"))
        {
            m_Animator.SetBool("Shooting", true);
        }
        else
        {
            m_Animator.SetBool("Shooting", false);
        }
        
        transform.Translate(movement, Space.Self);

        // Rotate the player to face the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(target);
        }

        // Fire a bullet on Mouse0 click
        _fireTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && _fireTimer <= 0f)
        {
            _fireTimer = fireDelay;
            
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(90,0,0));
            Instantiate(MuzzleFlashParticle, bulletSpawnPoint.position, quaternion.identity, gameObject.transform);
            var bulletRotation = bullet.transform.rotation;
            bulletRotation.eulerAngles = new Vector3(bulletRotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, bulletRotation.eulerAngles.z);
            bullet.transform.rotation = bulletRotation;
            
            //bullet.GetComponent<Rigidbody>().velocity = bulletDirection.normalized * bulletSpeed;
        }
    }
    private void PlayerTakeDamageEvent(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            if(!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                m_Animator.SetTrigger("Die");

            GameManager.Instance.playerState = GameManager.PlayerStates.dead;
            GameManager.Instance.gameState = GameManager.GameStates.fail;
            var b = m_Rigidbody.constraints == RigidbodyConstraints.FreezeAll;
        }
    }
}