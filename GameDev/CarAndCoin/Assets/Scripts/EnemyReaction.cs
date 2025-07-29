using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyReaction : MonoBehaviour
{
   public GameObject Car;
   
   public Text _coinsCount;
   private GameObject _coinsCountVisible;
   
   

    void Start()
    {
        Car = GameObject.Find("Car");
        _coinsCountVisible = GameObject.Find("CoinsCount");
        _coinsCount = GameObject.Find("CoinsCount").GetComponent<Text>();
    }

    
    void Update()
    {
        if(Car)
        {
            if(Vector3.Distance(Car.transform.position, transform.position) < 4f)
            {   
                GameObject.Find("EventSystem").GetComponent<Pause>().PauseTrue();

                if (int.Parse(_coinsCount.text) > PlayerPrefs.GetInt("Records"))
                {
                    PlayerPrefs.SetInt("Records", int.Parse(_coinsCount.text));
                }
                
                _coinsCountVisible.SetActive(false);
            }
        }
    }
}
