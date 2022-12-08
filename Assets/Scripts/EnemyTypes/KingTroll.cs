using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingTroll : MonoBehaviour
{
    [SerializeField] private EnemyType kingTrollData;

    void Start()
    {
        Debug.Log("Hi! My name is, " + kingTrollData.enemyTypeName);
        Debug.Log("My health is, " + kingTrollData.enemyHealth);
        Debug.Log("My speed is, " +kingTrollData.enemySpeed);
        Debug.Log("My damage is, " + kingTrollData.enemyDamage);
    }
}
