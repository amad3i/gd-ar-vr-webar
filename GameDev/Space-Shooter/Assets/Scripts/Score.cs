using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreCounter = 0;
    [SerializeField] private Text ScoreText;
    
    public void ScoreChange()
    {
        ScoreCounter++;
        ScoreText.text = ScoreCounter.ToString();
    }
}
