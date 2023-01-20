using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWaveSystem : MonoBehaviour
{
    private EnemyFactory m_EnemyFactory;
    [SerializeField]private Transform[] instantiateZones = new Transform[4];

    private float instantiateWaitTime = 0.1f;

    
    
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
        
        if (dayNum == 1)
        {
            for (int i = 0; i < dayNum * 5f; i++)
            {
                m_EnemyFactory.InstantiateTroll("smallTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }

            for (int i = 0; i < 2; i++)
            {
                m_EnemyFactory.InstantiateTroll("fastTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }
        }
        else if (dayNum == 2)
        {
            for (int i = 0; i < dayNum * 5f; i++)
            {
                m_EnemyFactory.InstantiateTroll("smallTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }

            for (int i = 0; i < 3; i++)
            {
                m_EnemyFactory.InstantiateTroll("fastTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }
            for (int i = 0; i < 2; i++)
            {
                m_EnemyFactory.InstantiateTroll("heavyTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }
        }
        else if (dayNum == 3)
        {
            for (int i = 0; i < 20; i++)
            {
                m_EnemyFactory.InstantiateTroll("smallTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }

            for (int i = 0; i < 5; i++)
            {
                m_EnemyFactory.InstantiateTroll("heavyTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }
            for (int i = 0; i < 2; i++)
            {
                m_EnemyFactory.InstantiateTroll("earlTroll", instantiateZones[GetRandomInstantiateZone()]);
                GameManager.Instance.numberOfActiveEnemies++;
                StartCoroutine(Wait());
            }
        }
            
    }

    private int  GetRandomInstantiateZone()
    {
        return Random.Range(0, instantiateZones.Length);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(instantiateWaitTime);
    }
    
}
