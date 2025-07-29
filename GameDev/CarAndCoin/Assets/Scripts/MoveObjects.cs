
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    
    void Start()
    {
       slider = GameObject.Find("Canvas/Slider").gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        transform.Translate(-1*Vector3.forward*Time.deltaTime*slider.value);
    }

    
}
