using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HeavyTroll : Troll
{
    [SerializeField] private EnemyType heavyTrollData;
    private Transform m_İnitialTarget;
    private NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.Find("Target").transform;
        m_Agent.speed = heavyTrollData.enemySpeed;
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
}
