using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MenuController : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Debug.Log("Click");
        gameObject.GetComponent<Pause>().Paused();
    }

    public void Restart()
    {
        Debug.Log("Click2");
        gameObject.GetComponent<Pause>().Paused();
        foreach (var obj in GameObject.FindGameObjectsWithTag("Destroy")) Destroy(obj);
        SteamVR_LoadLevel.Begin(SceneManager.GetActiveScene().name);
       
    }

}
