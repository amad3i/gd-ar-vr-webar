using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int Health = 2;
    public GameObject[] Enemys;
    public float maxY;
    public float minY;

    public float maxSpeed;
    public float minSpeed;
    public float maxDelay;
    public float minDelay;

     void Start()
    {
        StartCoroutine(Spawn());
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }
   
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY,maxY));
        
        GameObject e = Instantiate(Enemys[Random.Range(0, Enemys.Length)], pos, Quaternion.identity) as GameObject; 
        
        e.GetComponent<EnemyMove>().Speed = Random.Range(minSpeed, maxSpeed);

        Repeat();
        
        
    }
}
