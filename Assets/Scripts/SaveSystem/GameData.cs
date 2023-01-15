using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public DateTime totalPlayTime;

    public GameData()
    {
        this.totalPlayTime = new DateTime();
    }
}
