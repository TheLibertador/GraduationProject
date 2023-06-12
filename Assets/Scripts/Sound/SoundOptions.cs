using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundOptions : MonoBehaviour
{
    private AudioSource[] m_AudioSources;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_AudioSources = Resources.FindObjectsOfTypeAll<AudioSource>();
        AdjustVolumeOfSounds(m_AudioSources, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Prototype2_Scene")
        {
            m_AudioSources = Resources.FindObjectsOfTypeAll<AudioSource>();
            Debug.Log("Scene has changed" + m_AudioSources);
            AdjustVolumeOfSounds(m_AudioSources, 0);
        }
    }

    public void AdjustVolumeOfSounds(AudioSource[] m_audioSources, float volume)
    {
        foreach (var audioSource in m_audioSources)
        {
            audioSource.GetComponent<AudioSource>().volume = volume;
        }
    }

}
