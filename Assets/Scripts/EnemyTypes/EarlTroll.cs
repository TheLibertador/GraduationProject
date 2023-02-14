using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EarlTroll : Troll
{
    [SerializeField] private EnemyType earlTrollData;
    private Transform m_İnitialTarget;
    private NavMeshAgent m_Agent;
    private float m_Health;
    private int m_Damage;
    private Animator m_Animator;

    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.FindWithTag("Target").transform;
        m_Agent.speed = earlTrollData.enemySpeed;
        m_Health = earlTrollData.enemyHealth;
        m_Damage = (int)earlTrollData.enemyDamage;
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        FindNearestEnemy(earlTrollData.enemyRadius, m_İnitialTarget);
        SetAgentDestination();
        InvokeRepeating(nameof(SetAgentDestination),2f,1f);
    }

    private void SetAgentDestination()
    {
        m_Agent.SetDestination(FindNearestEnemy(earlTrollData.enemyRadius, m_İnitialTarget).position);
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
