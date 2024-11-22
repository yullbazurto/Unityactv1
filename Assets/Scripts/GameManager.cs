
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    

public TextMeshProUGUI textScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddScore()
    {
        score++;
        textScore.text = score.ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}