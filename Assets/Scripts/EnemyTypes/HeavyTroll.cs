using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTroll : MonoBehaviour
{
    [SerializeField] private EnemyType heavyTrollData;

    void Start()
    {
        Debug.Log("Hi! My name is, " + heavyTrollData.enemyTypeName);
        Debug.Log("My health is, " + heavyTrollData.enemyHealth);
        Debug.Log("My speed is, " +heavyTrollData.enemySpeed);
        Debug.Log("My damage is, " + heavyTrollData.enemyDamage);
    }
    
}
