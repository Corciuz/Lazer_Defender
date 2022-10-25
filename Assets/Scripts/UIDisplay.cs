using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]Slider HealthSlider;
    [SerializeField]Health PlayerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreText;
    ScoreKeeper ScoreKeeper;
    void Awake(){
        ScoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        HealthSlider.maxValue=PlayerHealth.GetHealth();
    }

   
    void Update()
    {
        HealthSlider.value=PlayerHealth.GetHealth();
        ScoreText.text=ScoreKeeper.GetScore().ToString("000000000");
        
    }
}
