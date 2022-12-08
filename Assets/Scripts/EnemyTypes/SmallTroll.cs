using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTroll : MonoBehaviour
{
    [SerializeField] private EnemyType smallTrollData;
    
    void Start()
    {
        Debug.Log("Hi! My name is, " + smallTrollData.enemyTypeName);
        Debug.Log("My health is, " + smallTrollData.enemyHealth);
        Debug.Log("My speed is, " +smallTrollData.enemySpeed);
        Debug.Log("My damage is, " + smallTrollData.enemyDamage);
    }
    
}
