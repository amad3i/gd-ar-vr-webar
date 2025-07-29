using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextChangeColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color Highlighted;
    private Color Normal;
 
    void Start()
    {
        Normal = GetComponentInChildren<Text>().color;
    }
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInChildren<Text>().color = Highlighted;
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInChildren<Text>().color = Normal;
    }
}
