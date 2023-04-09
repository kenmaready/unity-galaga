using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public static ScoreKeeper instance;
    private int score = 0;

    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton() {
        if (instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return score;
    }

    public void Add(int value) {
        score = Mathf.Max(score + value, 0);
    }

    public void Reset() {
        score = 0;
    }
}
