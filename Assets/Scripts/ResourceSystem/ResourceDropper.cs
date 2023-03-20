using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject iron;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject wood;
    

    private void DropResource(string id, int value, Transform position)
    {
        foreach (var item in ResourceManager.Instance.GetResourceDictionary())
        {
            if (item.Key == id)
            {
                //Instantiate<>(id, position);
            }
        }
    }
}
