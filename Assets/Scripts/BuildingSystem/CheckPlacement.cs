using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    private BuildingManager _buildingManager;
    private Material _wrongMaterial;
    private Material _defaultMaterial;

    private void Start()
    {
        _buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        _wrongMaterial = new Material(Shader.Find("Standard"));
        _wrongMaterial.color = Color.red;
        _defaultMaterial = GetComponent<MeshRenderer>().material;
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

    private void UpdateMaterials()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            if (_buildingManager.canPlace)
            {
                meshRenderer.material = _defaultMaterial;
            }
            else
            {
                meshRenderer.material = _wrongMaterial;
            }
        }
    }
}