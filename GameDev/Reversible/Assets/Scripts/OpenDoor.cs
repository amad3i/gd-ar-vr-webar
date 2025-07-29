using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("SetDoorOpen", true);
        anim.SetBool("SetDoorClose", false);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("SetDoorOpen", false);
        anim.SetBool("SetDoorClose", true);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }

   
}
