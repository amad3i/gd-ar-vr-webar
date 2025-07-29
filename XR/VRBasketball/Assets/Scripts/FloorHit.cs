using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHit : MonoBehaviour
{
    [SerializeField] private GameObject attract;
    [SerializeField] private GameObject net;
    private void OnTriggerEnter(Collider other)
    {
        attract.GetComponent<BasketHitTop>().whoIsFirst = false;
        net.GetComponent<BasketHitBottom>().whoIsSecond = false;
    }
}
