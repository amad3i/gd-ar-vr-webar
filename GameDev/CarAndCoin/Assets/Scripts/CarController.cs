using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CarController : MonoBehaviour
{
   [SerializeField] private Transform _target;
   [SerializeField] private Vector3 _moveLeftVector;
   [SerializeField] private Vector3 _moveRightVector;
   [SerializeField] private Slider slider;
   
   public bool isRight;
   public bool isLeft;

    void Start()
    {
       slider = GameObject.Find("Canvas/Slider").gameObject.GetComponent<Slider>();
    }
    void FixedUpdate()
    {
        Vector3 MovePosition = new Vector3(_target.position.x, 0, -20f);
        
        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if(isRight)
        {
           MoveRight();
        }
        
        if(isLeft)
        {
           MoveLeft();
        }
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, MovePosition, Time.deltaTime*((slider.value*0.2f)-0.5f)*3);
    }

    private void MoveRight()
    {
        if(_target.transform.position.x <= 7.8f)
            {
                _target.transform.Translate(_moveRightVector*Time.deltaTime*(slider.value*0.2f)*1.4f); 
            }
    }
    private void MoveLeft()
    {
         if(_target.transform.position.x >=-7.8f)
            {
                _target.transform.Translate(_moveLeftVector*Time.deltaTime*(slider.value*0.2f)*1.4f);
            }
    }
    public void TurnRight(bool isOn)
    {
        isRight = isOn;
    }

    public void TurnLeft(bool isOn)
    {
        isLeft = isOn;
    }
}
