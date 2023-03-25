using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMainCam : MonoBehaviour
{
    private Canvas mainMenuCanvas;
    void Awake()
    {
        mainMenuCanvas = gameObject.GetComponent<Canvas>();

        mainMenuCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        mainMenuCanvas.worldCamera = Camera.current;
    }

}
