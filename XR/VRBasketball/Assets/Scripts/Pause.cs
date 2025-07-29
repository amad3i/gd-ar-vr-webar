using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Pause : MonoBehaviour
{
    
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject pointer;
    private bool isPaused = false;



    private void Update()
    {
        if (SteamVR_Actions._default.menu.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Paused();
            
        }
    }

    public void Paused()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pause.SetActive(true);  
            pointer.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pointer.SetActive(false);
            pause.SetActive(false);  
            Time.timeScale = 1;  
        }
    }
}
