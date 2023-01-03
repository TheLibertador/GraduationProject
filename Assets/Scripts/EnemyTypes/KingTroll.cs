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
    
    private void Awake()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_İnitialTarget = GameObject.Find("Target").transform;
        m_Agent.speed = kingTrollData.enemySpeed;
        Debug.Log(m_İnitialTarget.position);

    }

    void Start()
    {
        FindNearestEnemy(kingTrollData.enemyRadius, m_İnitialTarget);
        
        InvokeRepeating(nameof(SetAgentDestination),3f,1f);
    }

    private void SetAgentDestination()
    {
        m_Agent.SetDestination(FindNearestEnemy(kingTrollData.enemyRadius, m_İnitialTarget).position);
    }
}
