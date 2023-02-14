using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerTakeDamageEvent(int damage);
    public static event PlayerTakeDamageEvent OnPlayerTakeDamageEvent;

    public static void OnOnPlayerTakeDamage(int damage)
    {
        OnPlayerTakeDamageEvent?.Invoke(damage);
    }
}
