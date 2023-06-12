using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    private AudioSource[] m_AudioSources;
    [SerializeField] private Slider soundSlider;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_AudioSources = Resources.FindObjectsOfTypeAll<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Prototype2_Scene")
        {
            m_AudioSources = Resources.FindObjectsOfTypeAll<AudioSource>();
            Debug.Log("Scene has changed" + m_AudioSources);
        }
    }

    public void AdjustVolumeOfSounds()
    {
        foreach (var audioSource in m_AudioSources)
        {
            audioSource.GetComponent<AudioSource>().volume = soundSlider.value;
        }
    }

}
