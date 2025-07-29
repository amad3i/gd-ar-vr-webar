using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReStartFunc()
    {
        Application.LoadLevel("Main");
    }
}
