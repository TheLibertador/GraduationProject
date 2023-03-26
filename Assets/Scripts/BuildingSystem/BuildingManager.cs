using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObj;

    private Vector3 pos;

    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;

    public float gridSize;
    private bool gridOn = true;
    public bool canPlace = true;
    public int rotateAmount = 90;



    private void Start()
    {
        
    }

    float RoundToNearestGrid(float pos)
    {
        //Changeable grid system
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }

        return pos;
    }


    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void SelectObject(int index)
    {
        pendingObj = Instantiate(objects[index], pos, transform.rotation);
    }
    
    void Update()
    {
        if (pendingObj != null)
        {
            if (gridOn)
            {
                pendingObj.transform.position = new Vector3(RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y), RoundToNearestGrid(pos.z));
            }
            else
            {
                pendingObj.transform.position = pos;
            }
           

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
            
        }   
    }

    public void RotateObject()
    {
        pendingObj.transform.Rotate(Vector3.up, rotateAmount);
    }
    void PlaceObject()
    {
        pendingObj.GetComponent<MeshCollider>().isTrigger = false;
        var rb =pendingObj.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(pendingObj.GetComponent<CheckPlacement>());
        pendingObj = null;
    }
    
    
}
