using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObj;

    private Vector3 pos;

    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;

    public float gridSize;
    [Header("GridOn değeri false olursa grid tamamen kapalı olucak")]
    public bool gridOn = true;
    public bool canPlace = true;
    public int rotateAmount = 90;
    public GameObject build;
    private bool isBuildActive = false;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject grid;
    private int selectedObj;
    [SerializeField] private GameObject warningTextPrefab;


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
    /*
     Örneğin, eğer gridSize değeri 5 olsaydı ve pos değeri 17 olsaydı, pos % gridSize işlemi 2 değerini verir.
     Bu, pos değerinin 5 adımından sonra kalanını temsil eder ve bu kalan değer, gridSize'ın bir tam katından
     küçük olduğu sürece, yani gridSize'ın yarısından küçük olduğu sürece, pos değeri önceki tam grid
     pozisyonuna düşürülür. Eğer pos değeri gridSize'ın yarısından büyükse, o zaman pos değeri sonraki tam grid
     pozisyonuna yuvarlanır.
     
     Eğer gridSize değeri 5 ve pos değeri 17 olsaydı, 
     pos değerinin gridSize'a bölümünden kalanı hesaplanır: 17 % 5 = 2 bu xDiff değeri, pos'un tam grid pozisyonuna göre ne kadar ileride olduğunu gösterir.
     xDiff değeri gridSize / 2'den (5 / 2 = 2.5) büyük olduğu için, pos değeri bir sonraki tam grid pozisyonuna (20) yuvarlanır.
       */


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
        if (index == 0 && ResourceManager.Instance.GetResourceValue("gold")> 250)
        {
            ResourceManager.Instance.SpendResource("gold", 250);
            Destroy(pendingObj);
            selectedObj = index;
            pendingObj = Instantiate(objects[index], pos, transform.rotation);
        }
        else if (index == 1 && ResourceManager.Instance.GetResourceValue("gold") > 500)
        {
            ResourceManager.Instance.SpendResource("gold", 500);
            Destroy(pendingObj);
            selectedObj = index;
            pendingObj = Instantiate(objects[index], pos, transform.rotation);
        }
        else if(index == 2 && ResourceManager.Instance.GetResourceValue("gold") > 1000)
        {
            ResourceManager.Instance.SpendResource("gold", 1000);
            Destroy(pendingObj);
            selectedObj = index;
            pendingObj = Instantiate(objects[index], pos, transform.rotation);
        }
        else if (index == 3 && ResourceManager.Instance.GetResourceValue("gold") > 100)
        {
            ResourceManager.Instance.SpendResource("gold", 100);
            Destroy(pendingObj);
            selectedObj = index;
            pendingObj = Instantiate(objects[index], pos, transform.rotation);
        }
        else if (index == 4 && ResourceManager.Instance.GetResourceValue("gold") > 300)
        {
            ResourceManager.Instance.SpendResource("gold", 300);
            Destroy(pendingObj);
            selectedObj = index;
            pendingObj = Instantiate(objects[index], pos, transform.rotation);
        }
        else
        {
            var textObject = Instantiate(warningTextPrefab, Vector3.zero, Quaternion.identity);
            textObject.GetComponent<TextMeshPro>().fontSize = 36;
            textObject.GetComponent<TextMeshPro>().text = "Not enough gold!";
            textObject.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        }
    }
    
    void Update()
    {
        if (pendingObj != null)
        {
            if (gridOn && build.activeSelf)
            {
                pendingObj.transform.position = new Vector3(RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y), RoundToNearestGrid(pos.z));
            }
            else if(!build.activeSelf)
            {
                Destroy(pendingObj);
            }
            else if(build.activeSelf)
            {
                pendingObj.transform.position = pos;
            }
            if (Input.GetMouseButtonDown(0) && canPlace && build.activeSelf && !EventSystem.current.IsPointerOverGameObject())
            {
                PlaceObject();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }   
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isBuildActive)
            {
                isBuildActive = false;
                build.SetActive(false);
                _playerController.isBuildModeEnabled = false;
                grid.SetActive(false);
            }
            else
            {
                isBuildActive = true;
                build.SetActive(true);
                _playerController.isBuildModeEnabled = true;
                grid.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isBuildActive)
            {
                isBuildActive = false;
                build.SetActive(false);
                _playerController.isBuildModeEnabled = false;
                grid.SetActive(false);
            }
            else
            {
                //TODO: Pause Menu
            }
        }
    }

    public void RotateObject()
    {
        pendingObj.transform.Rotate(Vector3.up, rotateAmount);
    }
    void PlaceObject()
    {
        Debug.Log(selectedObj);
        if (selectedObj != 4 && selectedObj != 3) // eğer duvar değilse
        {
            pendingObj.GetComponent<Autoturret>().enabled = true;
            Debug.Log("autoturret added");
        }
        pendingObj.GetComponent<MeshCollider>().isTrigger = false;
        var rb =pendingObj.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(pendingObj.GetComponent<CheckPlacement>());
        pendingObj = null;
    }
}
