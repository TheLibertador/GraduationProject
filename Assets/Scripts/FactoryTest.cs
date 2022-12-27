using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    private string m_EnemyType;
    private EnemyFactory m_Factory;
    
    void Start()
    {
        m_Factory = GetComponent<EnemyFactory>();

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_EnemyType = "smallTroll";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            m_EnemyType = "fastTroll";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            m_EnemyType = "heavyTroll";
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            m_EnemyType = "earlTroll";
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            m_EnemyType = "kingTroll";
        }

        m_Factory.InstantiateTroll(m_EnemyType);
        m_EnemyType = null;

    }
}
