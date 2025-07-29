using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
   
    public float Speed;
    public Vector2 Dir;
    void Update()
    {
        transform.Translate(Speed*Dir*Time.deltaTime, Space.World);    
    
    }
}
