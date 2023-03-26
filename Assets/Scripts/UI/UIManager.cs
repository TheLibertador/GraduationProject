using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button ContinueButton;


    [Header("Panels")] 
    [SerializeField] private GameObject optionsPanel;

    [Header("Canvas's")] 
    [SerializeField] private Canvas mainMenuCanvas;



    private void Start()
    {
       CheckContinueButtonActivity();
    }

    private void CheckContinueButtonActivity()
    {
        if (DataPersistenceManager.Instance.GetGameData())
        {
            ContinueButton.interactable = false;

        }
        else
        {
            ContinueButton.interactable = true;
        }
    }

    public void StartNewGame()
    {
        DataPersistenceManager.Instance.NewGame();
        mainMenuCanvas.enabled = false;
    }

    public void ActivateOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
}
