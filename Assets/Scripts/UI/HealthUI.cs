using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private HealthCount healthCount;
    [SerializeField]
    private Text healthLabel;

    private void Awake()
    {
        healthCount.HealthChanged += RefreshScore;
    }

    private void RefreshScore(int amount)
    {
        healthLabel.text = "Health: " + amount.ToString();
    }
}
