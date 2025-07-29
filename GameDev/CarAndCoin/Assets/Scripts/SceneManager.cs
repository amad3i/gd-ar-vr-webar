using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private GameObject CoinsCount;
    void Start()
    {
        CoinsCount = GameObject.Find("CoinsCount");    
    }

    public void StartPlay()
    {
        CoinsCount.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<Pause>().PauseFalse();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();  
    }
}
