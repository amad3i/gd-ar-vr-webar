using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject[] stars;
    
    public float maxY;
    public float minY;

    public float maxSpeed;
    public float minSpeed;
    
    public float maxScale;
    public float minScale;
    
    public Color[] colors;
    
    public float interval;
    
    void Start()
    {
        InvokeRepeating("Spawn", 0, interval);
    }

   
    void Spawn()
    {
        GameObject star = stars[Random.Range(0, stars.Length)];
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY,maxY));
        float scl = Random.Range(minScale, maxScale);
        Vector3 scale = new Vector3(scl,scl,scl);
        float speed = Random.Range(minSpeed, maxSpeed);
        Color color = colors[Random.Range(0,colors.Length)];
        
        GameObject s = Instantiate(star, pos, Quaternion.identity) as GameObject; 
        
        s.GetComponent<StarMove>().Speed = speed;
        s.GetComponent<SpriteRenderer>().color = color;
        s.transform.localScale = scale;
    }
    
}
