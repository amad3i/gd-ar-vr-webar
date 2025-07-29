using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject Bullet;
    public int Health = 1;
    public float Speed;
    public int DagameAmount = 1;
    public float MinDelay;
    public float MaxDelay;

    public Transform PointToShoot;
    public bool DelayIsTrue = true;
    public bool isShoot;
    
    public SoundManager soundManager; 
    
    void Start()
    {
        soundManager = GameObject.Find("PlayZone").GetComponent<SoundManager>();

        if (!(gameObject.name == "ShipPlayer")) 
        {
            StartCoroutine(SpawnBullets());
        }   
    }
    //Spawn enemy bullet
    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(Random.Range(MinDelay, MaxDelay));
        soundManager.PlaySound(2);
        Spawn();
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(SpawnBullets());
    }

    void Spawn()
    {
        
        Vector2 Position = new Vector2(PointToShoot.transform.position.x, PointToShoot.transform.position.y);
        
        GameObject bullet = Instantiate(Bullet, Position, Quaternion.identity) as GameObject;

        bullet.GetComponent<EnemyMove>().Speed = Speed*2;
    }
    


    void Update()
    {
        //Shoot for ShipPlayer
        if ((isShoot) && (gameObject.name == "ShipPlayer") && (DelayIsTrue))
        {
            soundManager.PlaySound(3);
            Spawn();
            DelayIsTrue = false;
            StartCoroutine(PlayerShootDelay());
        } 

        
    }
    //Delay shooting for ShipPlayer
    IEnumerator PlayerShootDelay()
    {
        yield return new WaitForSeconds(.3f);
        DelayIsTrue = true;
    }

    public void Fire (bool fire)
    {
        isShoot = fire;
    }
    

}
