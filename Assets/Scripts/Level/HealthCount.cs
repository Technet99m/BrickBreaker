using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCount : MonoBehaviour
{
    public event Action<int> HealthChanged;
    public event Action OutOfHealth;

    [SerializeField]
    private int maxHealth, penalty;

    private int health;

    private int Health { get => health; set { health = value; HealthChanged?.Invoke(health); } }

    public void Subscribe(Ball ball)
    {
        ball.BallFalled += OnBallFalled;
    }

    public void Init()
    {
        Health = maxHealth;
    }

    private void OnBallFalled()
    {
        Health -= penalty;
        if (Health <= 0)
            OutOfHealth?.Invoke();
    }
}
