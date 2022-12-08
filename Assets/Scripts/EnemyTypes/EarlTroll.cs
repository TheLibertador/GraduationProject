using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlTroll : MonoBehaviour
{
    [SerializeField] private EnemyType earlTrollData;

    void Start()
    {
        Debug.Log("Hi! My name is, " + earlTrollData.enemyTypeName);
        Debug.Log("My health is, " + earlTrollData.enemyHealth);
        Debug.Log("My speed is, " +earlTrollData.enemySpeed);
        Debug.Log("My damage is, " + earlTrollData.enemyDamage);
    }
}
