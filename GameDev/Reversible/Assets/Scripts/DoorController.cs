using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private int LastTime;
    private int Counter = 0;

    private void Start()
    {
        anim.SetBool("SetDoorOpen", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Counter == 0)
        {
            LastTime = TimeCounter.RewindTimer;
            CloseTheDoor();
            Counter++;
        }
    }

    private void FixedUpdate()
    {
        var time = TimeCounter.RewindTimer;
        if (Counter > 0)
        {
            if (TimeCounter.TimerReverse > time)

                if (time <= LastTime + 50)
                {
                    OpenTheDoor();
                }

            if (TimeCounter.TimerReverse < time)

                if (time >= LastTime - 50)
                {
                    CloseTheDoor();
                }
        }
    }

    private void OpenTheDoor()
    {
        anim.SetBool("SetDoorOpen", true);
        anim.SetBool("SetDoorClose", false);
    }

    private void CloseTheDoor()
    {
        anim.SetBool("SetDoorOpen", false);
        anim.SetBool("SetDoorClose", true);
    }
}