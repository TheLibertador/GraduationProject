using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public delegate void PlayerTakeDamageEvent(int damage);
    public static event PlayerTakeDamageEvent OnPlayerTakeDamageEvent;

    public static void OnOnPlayerTakeDamage(int damage)
    {
        OnPlayerTakeDamageEvent?.Invoke(damage);
        Debug.Log("I give damage!!!");
    }


    public delegate void TargetTakeDamageEvent(int damage);

    public static event TargetTakeDamageEvent OnTargetTakeDamageEvent;

    public static void OnOnTargetTakeDamage(int damage)
    {
        OnTargetTakeDamageEvent?.Invoke(damage);
    }

    public delegate void GameFailedEvent();
    public static event GameFailedEvent OnGameFailed;

    public static void OnOnGameFailed()
    {
        OnGameFailed?.Invoke();
    }


    

   
}
