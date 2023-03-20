using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    [SerializeField] private  GameObject gold;
    [SerializeField] private  GameObject iron;
    [SerializeField] private  GameObject stone;
    [SerializeField] private  GameObject wood;

    private Dictionary<string, GameObject> m_Resources = new Dictionary<string, GameObject>();

    private void Awake()
    {
        m_Resources.Add("gold", gold);
        m_Resources.Add("iron", iron);
        m_Resources.Add("stone", stone);
        m_Resources.Add("wood", wood);
    }

    private void DropResource(string id, int value, Vector3 position)
    {
        foreach (var item in m_Resources)
        {
            if (item.Key == id)
            {
                Instantiate(item.Value, position, Quaternion.identity);
            }
        }
    }
}
