using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sentenceUI;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject buildButton;
    [SerializeField] private PlayerController m_PlayerController;
    public static DialogueManager Instance { get; private set;}
    private Queue<string> m_Sentences = new Queue<string>();

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

    private void Start()
    {
        m_PlayerController.isBuildModeEnabled = true;
        buildButton.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //m_Sentences.Clear();
        foreach (var sentence in dialogue.sentences)
        {
            m_Sentences.Enqueue(sentence);
        }
        Debug.Log(m_Sentences.Count);
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if (m_Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = m_Sentences.Dequeue();
        sentenceUI.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("Dialogue Ended");
        Destroy(dialoguePanel.gameObject);
        m_PlayerController.isBuildModeEnabled = false;
        buildButton.SetActive(true);
    }
}
