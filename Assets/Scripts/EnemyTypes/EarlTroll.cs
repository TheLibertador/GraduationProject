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

    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.Find("Target").transform;
        m_Agent.speed = earlTrollData.enemySpeed;
        m_Health = earlTrollData.enemyHealth;
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
}
