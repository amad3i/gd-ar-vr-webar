using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    ObjectPooler objectPooler;
    
    void Start()
    {
        StartCoroutine(WaitingSpawn());
    }


    IEnumerator WaitingSpawn()
    { 
        yield return new WaitForSeconds(Random.Range(1f,2f));
        ObjectPooler.Instance.SpawnFromPool("Coin", transform.position, Quaternion.identity);
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(WaitingSpawn());
    }
}
