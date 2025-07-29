using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private int counter = 0;

    private void Start()
    {
        gameObject.GetComponent<Text>().text = counter.ToString();
    }

    public void IncrementCounter()
    {
        counter++;
        gameObject.GetComponent<Text>().text = counter.ToString();
    }

}
