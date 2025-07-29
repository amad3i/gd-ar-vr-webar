using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeReturn : MonoBehaviour
{
    [SerializeField] private GameObject _person;
    [SerializeField] private int reverseLimit = 5;
    [SerializeField] private Text reverseLimitText;
    [SerializeField] private Button reverseLimitUI;
    private List<List<Vector3>> _objectPosition = new List<List<Vector3>>();
    private List<int> _timeToStart = new List<int> {0};
    private List<GameObject> _dublicates;
    private bool _isReversing = false;
    private int _reverseCounter = 0;
    

    void Start()
    {
        reverseLimitText.text = reverseLimit.ToString();
        reverseLimitUI.image.color = new Color(1f, 0.16f, 0.18f);
        reverseLimitText.color = new Color(1f, 0.16f, 0.18f);
        for (int i = 0; i < reverseLimit; i++)
        {
            _objectPosition.Add(new List<Vector3>());
            _timeToStart.Add(0);
        }
        _dublicates = new List<GameObject>();
    }

    void Update()
    {
        if (_reverseCounter < reverseLimit)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                _timeToStart[_reverseCounter + 1] = TimeCounter.RewindTimer;

                _dublicates.Add(Instantiate(_person));

                if (_reverseCounter % 2 == 0)
                {
                    if (_reverseCounter > 0)
                    {
                        for (int i = _reverseCounter; i >= 0; i -= 2)
                        {
                            Color temp;
                            if (_dublicates[i].GetComponent<Renderer>().material.color.a > 0.1f)
                            {
                                temp = new Color(1f, 0f, 0f,
                                    _dublicates[i].GetComponent<Renderer>().material.color.a - 0.2f);
                            }
                            else
                            {
                                temp = new Color(1f, 0f, 0f, 0.1f);
                            }

                            _dublicates[i].GetComponent<Renderer>().material.SetColor("_Color", temp);
                            
                        }
                    }
                    else
                    {
                        var temp = new Color(1f, 0f, 0f, 0.8f);
                        _dublicates[_reverseCounter].GetComponent<Renderer>().material.SetColor("_Color", temp);
                    }

                    _isReversing = true;
                    reverseLimitUI.image.color = new Color(0.2f, 0.27f, 1f);
                    reverseLimitText.color = new Color(0.2f, 0.27f, 1f);
                    _person.GetComponent<Renderer>().material.color = Color.blue;
                }
                else
                {
                    if (_reverseCounter > 1)
                    {
                        for (int i = _reverseCounter; i > 0; i -= 2)
                        {
                            Color temp;
                            if (_dublicates[i].GetComponent<Renderer>().material.color.a > 0.1f)
                            {
                                temp = new Color(0f, 0f, 1f,
                                    _dublicates[i].GetComponent<Renderer>().material.color.a - 0.2f);
                            }
                            else
                            {
                                temp = new Color(0f, 0f, 1f, 0.1f);
                            }

                            _dublicates[i].GetComponent<Renderer>().material.SetColor("_Color", temp);
                            
                        }
                    }
                    else
                    {
                        var temp = new Color(0f, 0f, 1f, 0.8f);
                        _dublicates[_reverseCounter].GetComponent<Renderer>().material.SetColor("_Color", temp);
                    }
                    _isReversing = false;
                    reverseLimitUI.image.color = new Color(1f, 0.16f, 0.18f);
                    reverseLimitText.color = new Color(1f, 0.16f, 0.18f);
                    _person.GetComponent<Renderer>().material.color = Color.red;
                }
                _reverseCounter++;
                reverseLimitText.text = (reverseLimit - _reverseCounter).ToString();
                GetComponent<TimeCounter>().ReverseTime(_reverseCounter);
            }
        }
    }

    void FixedUpdate()
    {
        var time = TimeCounter.RewindTimer;
        if (_reverseCounter < reverseLimit)
        {
            _objectPosition[_reverseCounter].Add(_person.transform.position);
        }

        for (var i = 0; i < _dublicates.Count; i++)
        {
            if (i % 2 == 0)
            {
                if (time < _timeToStart[i + 1] && time >= _timeToStart[i])
                {
                    Debug.Log(time);
                    var a = time - _timeToStart[i];
                    var b = _objectPosition[i][a];
                    if (a == _objectPosition[i].Count - 1)
                    {
                        _dublicates[i].SetActive(false);
                    }
                    else
                    {
                        _dublicates[i].SetActive(true);
                    }
                    _dublicates[i].transform.position = b;
                }
            }
            else
            {
                if (time > _timeToStart[i + 1] && time <= _timeToStart[i])
                {
                    var a = time - _timeToStart[i + 1];
                    var b = _objectPosition[i].Count - a;
                    var c = _objectPosition[i][b];
                    if (b == 0)
                    {
                        _dublicates[i].SetActive(false);
                    }
                    else
                    {
                        _dublicates[i].SetActive(true);
                    }
                    _dublicates[i].transform.position = c;
                }
            }
        }
    }
}