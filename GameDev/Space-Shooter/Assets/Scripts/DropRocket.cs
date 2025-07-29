using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropRocket : MonoBehaviour
{
    [SerializeField] private Text RocketCounterText;
    [SerializeField] private int RocketCounter;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private int Health = 1; 
    [SerializeField] private float Speed;
    [SerializeField] private Transform PointToShoot;
    [SerializeField] private bool DelayIsTrue = true;
    
    public bool isReadyToDrop;
    public SoundManager soundManager; 
    
    void Start()
    {
        soundManager = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    
    void Update()
    {
        if ((isReadyToDrop) && (gameObject.name == "ShipPlayer") && (DelayIsTrue) && (RocketCounter > 0))
        {
            soundManager.PlaySound(1);
            RocketCounterChange();   
            Spawn();
            DelayIsTrue = false;
            StartCoroutine(PlayerShootDelay());
        } 
    }

    void RocketCounterChange()
    {
        RocketCounter--;
        RocketCounterText.text = RocketCounter.ToString();

    }
    void Spawn()
    {
        Vector2 Position = new Vector2(PointToShoot.transform.position.x, PointToShoot.transform.position.y);
        GameObject bullet = Instantiate(Bomb, Position, Quaternion.identity) as GameObject;
        Bomb.GetComponent<EnemyMove>().Speed = Speed;
    }

    IEnumerator PlayerShootDelay()
    {
        yield return new WaitForSeconds(5f);
        DelayIsTrue = true;
    }

    public void Drop (bool Drop)
    {
        isReadyToDrop = Drop;
    }

}
