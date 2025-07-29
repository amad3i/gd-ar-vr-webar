using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveRecords : MonoBehaviour
{
    public Text MyRecord;
    private Text CoinsCount;

    void Start()
    {
        MyRecord.text = PlayerPrefs.GetInt("Records").ToString(); 
    }

}