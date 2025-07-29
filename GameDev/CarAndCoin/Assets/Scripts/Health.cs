using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image[] _lifePoints;
    [SerializeField] private Color[] _lifeColors;
    [SerializeField] private int _health = 5;
    [SerializeField] private Transform _target;
    public GameObject Car;
    public Text coinsCount;
    private GameObject _coinsCountVisible;
    
    private bool _delayIsTrue = true;

    void Start()
    {
        Car = GameObject.Find("Car");
        _coinsCountVisible = GameObject.Find("CoinsCount");
        coinsCount = GameObject.Find("CoinsCount").GetComponent<Text>();
    }
    void Update()
    {
        if((_target.transform.position.x >= 7.5f)&&(_delayIsTrue))
        {
            Damage();
        }
        if((_target.transform.position.x <=-7.6f)&&(_delayIsTrue))
        {
            Damage();
        }
    }
    public void Damage()
    {
        _delayIsTrue = false;
        _health -= 1;
        StartCoroutine(DelayDamage());
        
        if (_health <= 0)
        {
            GameOver();
        }
        LifeChange();

    }

    IEnumerator DelayDamage()
    {    
        yield return new WaitForSeconds(2f);
        _delayIsTrue = true;
    }
    public void LifeChange()
    {
        for (int i = 0; i < _lifePoints.Length; i++)
        {
            if(i < _health)
            {
                _lifePoints[i].color = _lifeColors[0];
            }
            else 
            {
                _lifePoints[i].color = _lifeColors[1];
            } 
        }
    }
    public void GameOver()
    {
        if(Car)
        {
            GameObject.Find("EventSystem").GetComponent<Pause>().PauseTrue();

            if (int.Parse(coinsCount.text) > PlayerPrefs.GetInt("Records"))
            {
                PlayerPrefs.SetInt("Records", int.Parse(coinsCount.text));
            }
                
            _coinsCountVisible.SetActive(false);
            
        }
    }
}
