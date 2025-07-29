using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCheker : MonoBehaviour
{
    [SerializeField] private GameObject attract;
    [SerializeField] private GameObject net;
    [SerializeField] private GameObject text;
    
   
  
    
    void Update()
    {
        var isTopEnter = attract.GetComponent<BasketHitTop>().isHitTop;
        var isBottomEnter = net.GetComponent<BasketHitBottom>().isHitBottom;
        
        if (isBottomEnter && isTopEnter)
        {
            text.GetComponent<Counter>().IncrementCounter();
            attract.GetComponent<BasketHitTop>().isHitTop = false;
            net.GetComponent<BasketHitBottom>().isHitBottom = false;
        }
    }
}
