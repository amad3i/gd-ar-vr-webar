using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void StartPause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}
