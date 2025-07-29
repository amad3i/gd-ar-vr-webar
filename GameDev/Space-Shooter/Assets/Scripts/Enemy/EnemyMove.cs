using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{    public float Speed;
    public Vector2 Dir;

    public GameObject fx;

    private GameObject ShipPlayer;


    void Update()
    {
        transform.Translate(Speed*Dir*Time.deltaTime, Space.World);    
    }

    private void OnDestroy()
    {
        if(GameObject.Find("ShipPlayer").GetComponent<ShipController>().Health > 0)
        {
        GameObject ExplosionEffect = Instantiate(fx,transform.position,Quaternion.identity) as GameObject;
		ExplosionEffect.GetComponent<ParticleSystem>().Play();
		Destroy(ExplosionEffect,ExplosionEffect.GetComponent<ParticleSystem>().duration);   
        } 
    }


}
