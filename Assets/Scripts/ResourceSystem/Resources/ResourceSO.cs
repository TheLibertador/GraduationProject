using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Resource Type", menuName = "Resource") ]
public class ResourceSO : ScriptableObject
{
    public string id;
    public int value;
}
