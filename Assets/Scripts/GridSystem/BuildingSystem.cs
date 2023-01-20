using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Current;

    public GridLayout gridLayout;

    private Grid m_Grid;

    [SerializeField] private Tilemap mainTilemap;

    [SerializeField] private Tile whiteTile;

    public GameObject prefab1;
    public GameObject prefab2;

    private PlacableObject _ObjectToPlace;
    [SerializeField] private Text _errorText;

    /*
    public class GridObject
    {
        public override string ToString()
        {
            return x + ", " + z;
        }
    }
*/
    
    private void Awake()
    {
        Current = this;
        m_Grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            InitializeWithObject(prefab1);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            InitializeWithObject(prefab2);
        }

        if (!_ObjectToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(_ObjectToPlace))
            {
                _ObjectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(_ObjectToPlace.GetStartPosition());
                TakeArea(start, _ObjectToPlace.Size);
            }
            else
            {
                Destroy((_ObjectToPlace.gameObject));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(_ObjectToPlace.gameObject);
        }
        */
        
    }
    
    public void CheckIfCanPlaced()
    {
        if (!_ObjectToPlace)
        {
            return;
        }
        
        if (CanBePlaced(_ObjectToPlace))
        {
            _ObjectToPlace.Place();
            Vector3Int start = gridLayout.WorldToCell(_ObjectToPlace.GetStartPosition());
            TakeArea(start, _ObjectToPlace.Size);
        }
        else
        {
            Destroy(_ObjectToPlace.gameObject);
            StartCoroutine(DisplayError());
        }
    }

    IEnumerator DisplayError()
    {
        _errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _errorText.gameObject.SetActive(false);
    }

    public void DiscardBuilding()
    {
        Destroy(_ObjectToPlace.gameObject);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = m_Grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        _ObjectToPlace = obj.GetComponent<PlacableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    private bool CanBePlaced(PlacableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(_ObjectToPlace.GetStartPosition());
//        area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);
        area.size = new Vector3Int(placeableObject.Size.x + 1, placeableObject.Size.y + 1, placeableObject.Size.z);

        TileBase[] baseArray = GetTilesBlock(area, mainTilemap);
        foreach (var b in baseArray)
        {
            if (b == whiteTile)
            {
                return false;
            }
        }
        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        mainTilemap.BoxFill(start, whiteTile, start.x,start.y,start.x+size.x,start.y+size.y);
        Debug.Log(start.x);
        Debug.Log(start.x+size.x);
        Debug.Log(start.y);
        Debug.Log(start.y+size.y);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
