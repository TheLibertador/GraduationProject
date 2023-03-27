using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
   [SerializeField] private float health = 1000f;

   private void Start()
   {
      EventManager.OnTargetTakeDamageEvent += GetDamage;
   }

   private void GetDamage(int damage)
   {
      health -= damage;
      
      if (health <= 0f)
      {
         GameManager.Instance.gameState = GameManager.GameStates.fail;
      }
   }
   
}
