using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int score;

    private int Score { get => score;set { score = value; ScoreChanged?.Invoke(score); } }


    public void Subscribe(LevelManager levelManager)
    {
        levelManager.BrickDestroyed += AddScore;
    }

    public void Init()
    {
        Score = 0;
    }

    private void AddScore(BrickType type)
    {
        Score += type.Score;
        
    }
}
