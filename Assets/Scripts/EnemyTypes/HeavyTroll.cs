using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HeavyTroll : Troll
{
    [SerializeField] private EnemyType heavyTrollData;
    private Transform m_İnitialTarget;
    private NavMeshAgent m_Agent;
    private int m_Health;
    private int m_Damage;
    private Animator m_Animator;

    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.FindWithTag("Target").transform;
        m_Agent.speed = heavyTrollData.enemySpeed;
        m_Health = (int)heavyTrollData.enemyHealth;
        m_Damage = (int)heavyTrollData.enemyDamage;
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        FindNearestEnemy(heavyTrollData.enemyRadius, m_İnitialTarget);
        SetAgentDestination();
        InvokeRepeating(nameof(SetAgentDestination),2f,1f);
    }

    private void SetAgentDestination()
    {
        m_Agent.SetDestination(FindNearestEnemy(heavyTrollData.enemyRadius, m_İnitialTarget).position);
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                m_Animator.SetTrigger("Attack");
            EventManager.OnOnPlayerTakeDamage(m_Damage);
        }
        
    }
}
