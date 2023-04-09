using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health health;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreDisplay;
    private ScoreKeeper sk;

    private void Awake() {
        sk = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = health.GetHealth();
        healthSlider.value = healthSlider.maxValue;
        scoreDisplay.text = "0".PadLeft(8,'0');
    }

    void Update()
    {
        healthSlider.value = health.GetHealth();
        scoreDisplay.text = sk.GetScore().ToString().PadLeft(8,'0');
    }
}
