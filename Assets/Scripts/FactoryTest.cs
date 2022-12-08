using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    private string enemyType;
    private EnemyFactory factory;
    
    void Start()
    {
        factory = GetComponent<EnemyFactory>();

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            enemyType = "smallTroll";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            enemyType = "fastTroll";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            enemyType = "heavyTroll";
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            enemyType = "earlTroll";
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            enemyType = "kingTroll";
        }

        factory.InstantiateTroll(enemyType);
        enemyType = null;

    }
}
