using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private bool isOpenMenu = false;
    [SerializeField] private GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        if (isOpenMenu)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }

        isOpenMenu = !isOpenMenu;
    }

    public void RestartAllGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    public void RestartLvl()
    {
        GameObject.Find("TimeController").GetComponent<TimeCounter>().Reset();
        SceneManager.LoadScene(NewSceneManager._lvl);
        Time.timeScale = 1;
    }
}