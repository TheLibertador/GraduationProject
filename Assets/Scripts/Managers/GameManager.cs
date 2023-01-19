using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set;}
   
   public int numberOfActiveEnemies = 0;


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
}