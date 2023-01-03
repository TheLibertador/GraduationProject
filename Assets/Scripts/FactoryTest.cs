using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    [SerializeField] private Transform instantiateZone;
    private string m_EnemyType;
    private EnemyFactory m_Factory;
    
    void Start()
    {
        m_Factory = GetComponent<EnemyFactory>();

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            m_EnemyType = "smallTroll";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            m_EnemyType = "fastTroll";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            m_EnemyType = "heavyTroll";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            m_EnemyType = "earlTroll";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            m_EnemyType = "kingTroll";
        }

        m_Factory.InstantiateTroll(m_EnemyType,instantiateZone);
        m_EnemyType = null;

    }
}
