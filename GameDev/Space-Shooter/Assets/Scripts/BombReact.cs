using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombReact : MonoBehaviour
{
    public SoundManager soundManager; 

    void Start()
    {
        soundManager = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemyB"))
        {
            soundManager.PlaySound(0);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if ((other.gameObject.CompareTag("Enemy")))
        {
            soundManager.PlaySound(0);
            other.gameObject.GetComponent<EnemyHealth>().Damage(10);
            Destroy(gameObject);
        }
    }
}
