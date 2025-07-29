using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    
    void Update()
    {
        if (transform.position.x <= -10)
        {
            DestroyObj();
        }
    }
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
