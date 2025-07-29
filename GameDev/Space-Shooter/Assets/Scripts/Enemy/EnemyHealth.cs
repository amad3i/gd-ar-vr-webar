using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float Health;
    public ShipController Ship;
    public Score Score;
    
    public SoundManager soundManager;
    
    
    void Start()
    {
        
        soundManager = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        Ship = GameObject.Find("ShipPlayer").GetComponent<ShipController>();
        Score = GameObject.Find("Score").GetComponent<Score>();
    }


    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("shipB"))
        {
            Damage(Ship.PlayerDamage);
            Destroy(other.gameObject);
        }
        if ((other.gameObject.CompareTag("Ship")))
        {
            soundManager.PlaySound(0);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enemyB"))
        {
            Damage(1);
            Destroy(other.gameObject);
        }

         if ((other.gameObject.CompareTag("Enemy")))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void Damage(int DamageAmount)
    {
        Health -= DamageAmount;
        if (Health <= 0)
        {
            Score.ScoreChange();
            Destroy(gameObject);
        }
    }    

    public void GameOver()
    {
        Application.LoadLevel("GameOver");
    }

}
