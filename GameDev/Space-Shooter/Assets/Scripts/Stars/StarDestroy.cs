using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroy : MonoBehaviour
{

    void Update()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
