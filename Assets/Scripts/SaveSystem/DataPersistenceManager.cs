using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;

    private FileDataHandler dataHandler;
    private GameData m_GameData;
    public static DataPersistenceManager Instance { get; private set; }
    private List<IDataPersistence> m_DataPersistenceObjects;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
           
        }
        else
        {
            Instance = this;
        }
        
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.m_DataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    public void NewGame()
    {
        m_GameData = new GameData();
    }

    public void LoadGame()
    {
        m_GameData = dataHandler.Load();
        if (m_GameData == null)
        {
            Debug.Log("There are no prior game data, initializing new gameData");
            NewGame();
        }
       
        foreach (IDataPersistence dataPersistenceObj in m_DataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(m_GameData);
        }
        
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in m_DataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(m_GameData);
        }
        dataHandler.Save(m_GameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool GetGameData()
    {
        if(m_GameData == null)
        {
            return false;
        }
        
        return true;
        
    }
}
