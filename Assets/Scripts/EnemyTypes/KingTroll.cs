using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class KingTroll : Troll
{

    [SerializeField] private EnemyType kingTrollData;
    private Transform m_İnitialTarget;
    private NavMeshAgent m_Agent;
    public float m_Health;
    private int m_Damage;
    private Animator m_Animator;

    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.FindWithTag("Target").transform;
        m_Agent.speed = kingTrollData.enemySpeed;
        m_Health = (int)kingTrollData.enemyHealth;
        m_Damage = (int)kingTrollData.enemyDamage;
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        FindNearestEnemy(kingTrollData.enemyRadius, m_İnitialTarget);
        SetAgentDestination();
        InvokeRepeating(nameof(SetAgentDestination),2f,1f);
    }

    private void SetAgentDestination()
    {
        m_Agent.SetDestination(FindNearestEnemy(kingTrollData.enemyRadius, m_İnitialTarget).position);
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                m_Animator.SetTrigger("Attack");
            EventManager.OnOnPlayerTakeDamage(m_Damage);
        }
        
        if (other.gameObject.CompareTag("Target"))
        {
            if(!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                m_Animator.SetTrigger("Attack");
            
            EventManager.OnOnTargetTakeDamage(m_Damage);
        }
        
    }
}
