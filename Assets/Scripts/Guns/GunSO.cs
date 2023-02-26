using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Gun Type", menuName = "Gun")]
public class GunSO : ScriptableObject
{
    public float damage;
    public float fireRate;
    public int clipSize;
}
