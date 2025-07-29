using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHitBottom : MonoBehaviour
{
    [SerializeField] private GameObject attract;
    public bool isHitBottom = false;
    public bool whoIsSecond = false;
    private void OnTriggerEnter(Collider other)
    {
        whoIsSecond = true;
        if (attract.GetComponent<BasketHitTop>().whoIsFirst)
        {
            isHitBottom = true;
        }
        else
        {
            attract.GetComponent<BasketHitTop>().whoIsFirst = false;
            whoIsSecond = false;
        }

    }
    
}
