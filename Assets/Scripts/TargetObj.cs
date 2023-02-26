using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
   private float m_Health = 100f;

   private void Start()
   {
      EventManager.OnTargetTakeDamageEvent += GetDamage;
   }

   private void GetDamage(int damage)
   {
      m_Health -= damage;
      
      if (m_Health <= 0f)
      {
         GameManager.Instance.gameState = GameManager.GameStates.fail;
      }
   }
   
}
