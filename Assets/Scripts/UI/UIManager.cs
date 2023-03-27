using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance { get; private set;}
    
    [Header("Buttons")] 
    [SerializeField] private Button ContinueButton;


    [Header("Panels")] 
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject failPanel;

    [Header("Sliders")] [SerializeField] private Slider healthSlider;

    [Header("Canvas's")] 
    [SerializeField] private Canvas mainMenuCanvas;


    [Header("ResourceTexts")] 
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text ironText;
    [SerializeField] private TMP_Text stoneText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        CheckContinueButtonActivity();
        EventManager.OnGameFailed += ActivateFailPanel;
    }

    private void FixedUpdate()
    {
        DisplayResourceAmounts();
        
    }

    public void StartNewGame()
    {
        GameManager.Instance.gameState = GameManager.GameStates.ongoing;
        GameManager.Instance.playerState = GameManager.PlayerStates.alive;
        DataPersistenceManager.Instance.NewGame();
        mainMenuCanvas.enabled = false;
        hudPanel.SetActive(true);
        SceneManager.LoadScene("Prototype2_Scene");
        failPanel.SetActive(false);
    }

    public void ActivateFailPanel()
    {
        failPanel.SetActive(true);
        mainMenuCanvas.enabled = false;
        hudPanel.SetActive(false);
    }

    public void ReturnMainMenu()
    {
        GameManager.Instance.gameState = GameManager.GameStates.ongoing;
        GameManager.Instance.playerState = GameManager.PlayerStates.alive;
        SceneManager.LoadScene("MainMenu");
    }

    public void DisplayResourceAmounts()
    {
        goldText.text = ResourceManager.Instance.GetResourceValue("gold").ToString();
        woodText.text = ResourceManager.Instance.GetResourceValue("wood").ToString();
        ironText.text = ResourceManager.Instance.GetResourceValue("iron").ToString();
        stoneText.text = ResourceManager.Instance.GetResourceValue("stone").ToString();
    }

    
    
    #region ContinueButton
        private void CheckContinueButtonActivity()
        {
            if (!DataPersistenceManager.Instance.GetGameData())
            {
                ContinueButton.interactable = false;

            }
            else
            {
                ContinueButton.interactable = true;
            }
        }

        public void ContinueGame()
        {
            DataPersistenceManager.Instance.LoadGame();
            SceneManager.LoadScene("Prototype2_Scene");
            mainMenuCanvas.enabled = false;
            hudPanel.SetActive(true);
        }
    

    #endregion
    
    #region OptionsPanel
    public void ActivateOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void DeActivateOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    
    #endregion
    
    
  
}
