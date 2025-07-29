using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    [SerializeField] private GameObject person;
    private float _speed = 30f;
    private Rigidbody _rb;
    private Vector3 _input;

    private void Start()
    {
        _rb = person.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _input = new Vector3(-(Input.GetAxis("Vertical")),0,Input.GetAxis("Horizontal"));
    }

    private void FixedUpdate()
    {
        MovePersonFunc(_input);
    }

    private void MovePersonFunc(Vector3 direction)
    {
        _rb.velocity =  direction * _speed;
    }
    
}
