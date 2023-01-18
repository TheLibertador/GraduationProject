using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastTroll : Troll
{
    [SerializeField] private EnemyType fastTrollData;
    private Transform m_İnitialTarget;
    private NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.Find("Target").transform;
        m_Agent.speed = fastTrollData.enemySpeed;
    }

    void Start()
    {
        FindNearestEnemy(fastTrollData.enemyRadius, m_İnitialTarget);
        SetAgentDestination();
        InvokeRepeating(nameof(SetAgentDestination),2f,1f);
    }

    private void SetAgentDestination()
    {
        m_Agent.SetDestination(FindNearestEnemy(fastTrollData.enemyRadius, m_İnitialTarget).position);
    }
}
