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
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //m_Sentences.Clear();
        m_PlayerController.isBuildModeEnabled = true;
        buildButton.SetActive(false);
        foreach (var sentence in dialogue.sentences)
        {
            m_Sentences.Enqueue(sentence);
        }
        
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
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        m_PlayerController.isBuildModeEnabled = false;
        buildButton.SetActive(true);
    }
}
