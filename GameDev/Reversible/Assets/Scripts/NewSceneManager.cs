using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneManager : MonoBehaviour
{
    private static int lvlLimit = 5;
    public static int _lvl = 0;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("TimeController").GetComponent<TimeCounter>().Reset();
        _lvl++;
        if(_lvl < lvlLimit)
            SceneManager.LoadScene(_lvl);
        if (_lvl == lvlLimit)
            SceneManager.LoadScene(lvlLimit);
    }

    
}
