
using System.Collections;

using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    
    ObjectPooler objectPooler;
    public static int SpawnCounter = 1;

    
    void Start()
    {
        StartCoroutine(WaitingSpawn());
    }


    
    IEnumerator WaitingSpawn()
    {
        
        yield return new WaitForSeconds(Random.Range(1f, 3f)); 
        
        
        if (SpawnCounter < 2)
        {
            
            ObjectPooler.Instance.SpawnFromPool("Box", transform.position, Quaternion.identity);
            SpawnCounter++;
        }
        else 
        {
            yield return new WaitForSeconds(.5f);  
            SpawnCounter = 0;
        }
        Repeat();
    }


    void Repeat()
    {
        StartCoroutine(WaitingSpawn());
    }

   
}
