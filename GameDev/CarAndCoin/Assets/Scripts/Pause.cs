using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Tap;


    void Start()
    {  
        PauseFalse();

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTrue();
        }
    }

    public void PauseTrue()
    {
        Time.timeScale = 0;
        Tap.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void PauseFalse()
    {
        Time.timeScale = 1;
        Tap.SetActive(true);
        PauseMenu.SetActive(false);
    }

}
