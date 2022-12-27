using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Troll Type", menuName = "Troll")]
public class EnemyType : ScriptableObject
{
    public string enemyTypeName = "Type";
    
    public float enemyHealth = 10f;
    public float enemySpeed = 5f;
    public float enemyDamage = 5f;
    public float enemyRadius = 10f;
}
