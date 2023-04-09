using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    ScoreKeeper sk;
    
    private void Awake() {
        sk = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreDisplay.text = sk.GetScore().ToString().PadLeft(8, '0');
    }

}
