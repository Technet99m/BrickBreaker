using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private ScoreCount scoreCount;
    [SerializeField]
    private Text scoreLabel;

    private void Awake()
    {
        scoreCount.ScoreChanged += RefreshScore;
    }

    private void RefreshScore(int amount)
    {
        scoreLabel.text = "Score: " + amount.ToString();
    }
}
