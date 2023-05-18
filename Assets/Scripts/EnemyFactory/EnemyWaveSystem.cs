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
    private int dayNum = 0;
    
    
    
    private void Start()
    {
        m_EnemyFactory = GetComponent<EnemyFactory>();
    }

    private void Update()
    {
        if (GameManager.Instance.numberOfActiveEnemies <= 2 && !TimeController.Instance.CheckIfSunIsUp())
        {
            InstantiateWave();
        }
    }

    private void InstantiateWave()
    {
        InstantiateSmallTroll();
        InstantiateFastTroll();
        InstantiateHeavyTroll();
        InstantiateEarlTroll();
        InstantiateKingTroll();
    }

    private int  GetRandomInstantiateZone()
    {
        return Random.Range(0, instantiateZones.Length);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(instantiateWaitTime);
    }

    private void InstantiateSmallTroll()
    {
        //The instantiation ratio for small troll is 3x
        for (int i = 0; i < TimeController.Instance.GetCurrentDay() * 3f; i++)
        {
            m_EnemyFactory.InstantiateTroll("smallTroll", instantiateZones[GetRandomInstantiateZone()]);
            GameManager.Instance.numberOfActiveEnemies++;
            StartCoroutine(Wait());
        }
    }

    private void InstantiateFastTroll()
    {
        //The instantiation ratio for fast troll is 2x
        for (int i = 0; i < 2 * TimeController.Instance.GetCurrentDay(); i++)
        {
            m_EnemyFactory.InstantiateTroll("fastTroll", instantiateZones[GetRandomInstantiateZone()]);
            GameManager.Instance.numberOfActiveEnemies++;
            StartCoroutine(Wait());
        }
    }

    private void InstantiateHeavyTroll()
    {
        //The instantiation ratio for heavy troll is 2(x-2)
        for (int i = 0; i < 2*(TimeController.Instance.GetCurrentDay() - 2) ; i++)
        {
            m_EnemyFactory.InstantiateTroll("heavyTroll", instantiateZones[GetRandomInstantiateZone()]);
            GameManager.Instance.numberOfActiveEnemies++;
            StartCoroutine(Wait());
        }
    }
    private void InstantiateEarlTroll()
    {
        //The instantiation ratio for earl troll is x-3
        for (int i = 0; i < TimeController.Instance.GetCurrentDay() - 3; i++)
        {
            m_EnemyFactory.InstantiateTroll("earlTroll", instantiateZones[GetRandomInstantiateZone()]);
            GameManager.Instance.numberOfActiveEnemies++;
            StartCoroutine(Wait());
        }
    }

    private void InstantiateKingTroll()
    {
        //The instantiation ratio for king troll is x-5
        for (int i = 0; i < TimeController.Instance.GetCurrentDay() - 5; i++)
        {
            m_EnemyFactory.InstantiateTroll("kingTroll", instantiateZones[GetRandomInstantiateZone()]);
            GameManager.Instance.numberOfActiveEnemies++;
            StartCoroutine(Wait());
        }
    }

}
