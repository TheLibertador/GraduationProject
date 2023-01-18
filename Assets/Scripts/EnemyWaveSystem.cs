using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWaveSystem : MonoBehaviour, IDataPersistence
{
    private EnemyFactory m_EnemyFactory;
    [SerializeField]private Transform[] instantiateZones = new Transform[4];

    
    
    private void Start()
    {
        m_EnemyFactory = GetComponent<EnemyFactory>();
    }

    private void Update()
    {
        if (GameManager.Instance.numberOfActiveEnemies == 0 && !TimeController.Instance.CheckIfSunIsUp())
        {
            InstantiateWave(TimeController.Instance.GetCurrentDay());
        }
    }

    private void InstantiateWave(int dayNum)
    {
        int instantiateZoneIndex = GetRandomInstantiateZone();
        
            for (int i = 0; i < dayNum * 10f; i++)
            {
                m_EnemyFactory.InstantiateTroll("kingTroll", instantiateZones[instantiateZoneIndex]);
                GameManager.Instance.numberOfActiveEnemies++;
            }

            for (int i = 0; i < dayNum - 5; i++)
            {
                m_EnemyFactory.InstantiateTroll("kingTroll", instantiateZones[instantiateZoneIndex]);
                GameManager.Instance.numberOfActiveEnemies++;
            }
            
        
    }

    private int  GetRandomInstantiateZone()
    {
        return Random.Range(0, instantiateZones.Length);
    }
    
    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        
    }
}
