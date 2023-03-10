using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<string, float> m_Resources = new Dictionary<string, float>()
    {
        {"wood", 0f}, {"iron", 0f}, {"gold", 0f}
    };


    private void Start()
    {
        Debug.Log(GetResourceValue("wood"));
        AddResource("wood", 545f);
        SpendResource("wood", 300f);
        
        Debug.Log(GetResourceValue("wood"));
        
        AddResourceType("hodor", 0f);
        
        Debug.Log(GetResourceValue("hodor"));
    }


    private void AddResourceType(string id, float value)
    {
        m_Resources.Add(id, value);
    }

    private float GetResourceValue(string id)
    {
        return m_Resources[id];
    }

    private bool TrySpendResource(string id, float spendValue)
    {
        if (m_Resources[id] > spendValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void AddResource(string id, float value)
    {
        m_Resources[id] += value;
    }

    private void SpendResource(string id, float value)
    {
        m_Resources[id] -= value;
    }
    
}
