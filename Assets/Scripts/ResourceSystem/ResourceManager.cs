using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set;}
    
    private Dictionary<string, int> m_Resources = new Dictionary<string, int>()
    {
        {"wood", 0}, {"iron", 0}, {"gold", 0}, {"stone", 0}
    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    

    public void AddResourceType(string id, int value)
    {
        m_Resources.Add(id, value);
    }

    public float GetResourceValue(string id)
    {
        return m_Resources[id];
    }

    public bool TrySpendResource(string id, int spendValue)
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

    public void AddResource(string id, int value)
    {
        m_Resources[id] += value;
    }

    public void SpendResource(string id, int value)
    {
        m_Resources[id] -= value;
    }
    
}
