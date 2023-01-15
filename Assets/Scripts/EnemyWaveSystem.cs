using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWaveSystem : MonoBehaviour
{
    private EnemyFactory m_EnemyFactory;
    [SerializeField]private Transform[] instantiateZones = new Transform[4];

    private void Start()
    {
        m_EnemyFactory = GetComponent<EnemyFactory>();
        InstantiateWave(10,"Start");
    }

    private void InstantiateWave(int dayNum , string gamePhase)
    {
        int instantiateZoneIndex = GetRandomInstantiateZone();
        if (gamePhase == "Start")
        {
            for (int i = 0; i < dayNum; i++)
            {
               
                m_EnemyFactory.InstantiateTroll("kingTroll", instantiateZones[instantiateZoneIndex]);
            }

            for (int i = 0; i < dayNum - 5; i++)
            {
                m_EnemyFactory.InstantiateTroll("kingTroll", instantiateZones[instantiateZoneIndex]);
            }
            
        }
    }

    private int  GetRandomInstantiateZone()
    {
        return Random.Range(0, instantiateZones.Length);
    }
    
}
