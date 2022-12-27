using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KingTroll : Troll
{
    [SerializeField] private EnemyType kingTrollData;
    [SerializeField] private Transform initialTarget;
    private NavMeshAgent m_Agent;

    private void Awake()
    {
        //initialTarget.position = new Vector3(-16.8f, 1f, 19.8f);
        Debug.Log(initialTarget);
    }

    void Start()
    {
        Debug.Log("Problem starts here!");
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        Debug.Log("My Type is == " + m_Agent.GetType());
        Debug.Log("Hi! My name is, " + kingTrollData.enemyTypeName);
        Debug.Log("My health is, " + kingTrollData.enemyHealth);
        Debug.Log("My speed is, " +kingTrollData.enemySpeed);
        Debug.Log("My damage is, " + kingTrollData.enemyDamage);
        FindNearestEnemy(kingTrollData.enemyRadius,initialTarget);
    }

    private void Update()
    {
        Debug.Log(FindNearestEnemy(kingTrollData.enemyRadius,initialTarget).position + "ITS MY TARGET");
        m_Agent.SetDestination(FindNearestEnemy(kingTrollData.enemyRadius, initialTarget).position);
    }
}
