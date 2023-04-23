using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set;}
   
   public int numberOfActiveEnemies = 0;
   
   public enum PlayerStates
   {
       alive,
       dead
   }

   public PlayerStates playerState;
   
   
   public enum GameStates
   {
       ongoing,
       build,
       pause,
       fail
   }

   public GameStates gameState;


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

      playerState = PlayerStates.alive;
   }

   private void Update()
   {
       CheckGameFailed();
   }

   private void CheckGameFailed()
   {
       if (gameState == GameStates.fail || playerState == PlayerStates.dead)
       {
           EventManager.OnOnGameFailed();
           Debug.Log("I ghave failed");
       }
   }
}
