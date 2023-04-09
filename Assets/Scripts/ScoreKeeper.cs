using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    private int score = 0;

    public int GetScore() {
        return score;
    }

    public void Add(int value) {
        score = Mathf.Max(score + value, 0);
        Debug.Log("Score is now: " + score);
    }

    public void Reset() {
        score = 0;
    }
}
