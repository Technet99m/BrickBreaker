using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public event Action GameFinished;

    public void Subscribe(LevelManager levelManager, HealthCount healthCount)
    {
        levelManager.AllBricksDestroyed += GameFinish;
        healthCount.OutOfHealth += GameFinish;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameFinish();
        }
    }

    private void GameFinish()
    {
        GameFinished?.Invoke();
    }

}
