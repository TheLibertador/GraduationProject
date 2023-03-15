using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceItem : MonoBehaviour
{
    [SerializeField] private ResourceSO resourceData;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResourceManager.Instance.AddResource(resourceData.id, resourceData.value);
        }
    }
}
