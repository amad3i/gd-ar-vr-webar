using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHitTop : MonoBehaviour
{
    
    [SerializeField] private GameObject net;
    public bool isHitTop = false;
    public bool whoIsFirst = false;
    
    private void OnTriggerEnter(Collider other)
    {
        whoIsFirst = true;
        if (!net.GetComponent<BasketHitBottom>().whoIsSecond)
        {
            isHitTop = true;
        }
        else
        {
            whoIsFirst = false;
            net.GetComponent<BasketHitBottom>().whoIsSecond = false;
        }
    }

}
