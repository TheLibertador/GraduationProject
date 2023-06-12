using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HeavyTroll : Troll
{
    [SerializeField] private EnemyType heavyTrollData;
    private Transform m_İnitialTarget;
    private NavMeshAgent m_Agent;
    public float m_Health;
    private int m_Damage;
    private Animator m_Animator;


    private bool isDamageCoroutineActive = false;

    [SerializeField] private AudioClip attack;
    private AudioSource audioSource;
    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.FindWithTag("Player").transform;
        m_Agent.speed = heavyTrollData.enemySpeed;
        m_Health = (int)heavyTrollData.enemyHealth;
        m_Damage = (int)heavyTrollData.enemyDamage;
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        FindNearestEnemy(heavyTrollData.enemyRadius, m_İnitialTarget);
        SetAgentDestination();
        InvokeRepeating(nameof(SetAgentDestination),0.1f,0.2f);
    }

    private void SetAgentDestination()
    {
        m_Agent.SetDestination(FindNearestEnemy(heavyTrollData.enemyRadius, m_İnitialTarget).position);
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                m_Animator.SetTrigger("Attack");
                if (audioSource != null && attack != null && !audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(attack);
                }
                if (!isDamageCoroutineActive)
                {
                    isDamageCoroutineActive = true;
                    StartCoroutine(WaitForAttackEnemy(1f, m_Damage));
                }
            }
               
        }
        if (other.gameObject.CompareTag("Target"))
        {
            if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                m_Animator.SetTrigger("Attack");
                if (audioSource != null && attack != null && !audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(attack);
                }
                if(!isDamageCoroutineActive)
                {
                    isDamageCoroutineActive = true;
                    StartCoroutine(WaitForAttackTarget(1f, m_Damage));
                }
            }
                
        }
    }
    
    protected IEnumerator WaitForAttackEnemy(float waitTime, int damage)
    {
        EventManager.OnOnPlayerTakeDamage(damage);
        UIManager.Instance.ShowLostHealth(damage);
        yield return new WaitForSeconds(waitTime);
        isDamageCoroutineActive = false;
    }
    protected IEnumerator WaitForAttackTarget(float waitTime, int damage)
    {
        EventManager.OnOnPlayerTakeDamage(damage);
        yield return new WaitForSeconds(waitTime);
        isDamageCoroutineActive = false;
    }
}
