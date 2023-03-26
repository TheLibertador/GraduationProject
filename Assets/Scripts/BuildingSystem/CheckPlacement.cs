using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    private BuildingManager _buildingManager;
    private Material _wrongMaterial;
    private Material _defaultMaterial;
    void Start()
    {
        _buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        _wrongMaterial = new Material(Shader.Find("Standard"));
        _wrongMaterial.color = Color.red;
    }
    
    private void OnTriggerExit(Collider other)
    {
        _buildingManager.canPlace = true;
        Debug.Log("can place");
        UpdateMaterials();
    }

    private void OnTriggerEnter(Collider other)
    {
        _buildingManager.canPlace = false;
        Debug.Log("cannot place");
        UpdateMaterials();
    }

    // Update is called once per frame
    void Awake()
    {
        _defaultMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }
    private void UpdateMaterials()
    {
        if (_buildingManager.canPlace)
        {
            gameObject.GetComponent<MeshRenderer>().material = _defaultMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = _wrongMaterial;
        }
    }
}
