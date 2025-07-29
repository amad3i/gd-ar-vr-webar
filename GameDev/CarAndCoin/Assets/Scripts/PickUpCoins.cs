using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpCoins : MonoBehaviour
{
    public Text CoinsCount;
    public GameObject Car;
    private GameObject MyRecord;
    
    void Start()
    {
        CoinsCount = GameObject.Find("CoinsCount").GetComponent<Text>();
        Car = GameObject.Find("Car");
        MyRecord = GameObject.Find("MyRecord");

    }
    
    void Update()
    {
        if(Car)
        {
            if(Vector3.Distance(Car.transform.position, transform.position) < 3f)
            {
                CoinsCount.text = (int.Parse(CoinsCount.text)+1).ToString();

                if (int.Parse(CoinsCount.text) > PlayerPrefs.GetInt("Records"))
                {
                    PlayerPrefs.SetInt("Records", int.Parse(CoinsCount.text));
                }
                gameObject.SetActive(false);
            }
        }
    }
}
