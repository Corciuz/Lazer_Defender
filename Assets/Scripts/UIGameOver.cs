using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameOver : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI ScoreText;
    ScoreKeeper ScoreKeeper;
    
    void Awake(){
        ScoreKeeper=FindObjectOfType<ScoreKeeper>();
       
    }
    
    void Start()
    {
        ScoreText.text="Your Score: \n"+ScoreKeeper.GetScore();
    }

    
}
