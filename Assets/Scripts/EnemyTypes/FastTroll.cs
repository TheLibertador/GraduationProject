using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTroll : Troll
{
    [SerializeField] private EnemyType fastTrollData;
    
    void Start()
    {
        Debug.Log("Hi! My name is, " + fastTrollData.enemyTypeName);
        Debug.Log("My health is, " + fastTrollData.enemyHealth);
        Debug.Log("My speed is, " +fastTrollData.enemySpeed);
        Debug.Log("My damage is, " + fastTrollData.enemyDamage);
    }
    
}
