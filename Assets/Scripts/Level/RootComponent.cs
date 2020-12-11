using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootComponent : MonoBehaviour
{
    
    [SerializeField]
    private LevelSpawner levelSpawner;
    [SerializeField]
    private ScoreCount scoreCount;
    [SerializeField]
    private HealthCount healthCount;
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private GameLoop gameLoop;
    [SerializeField]
    private PaddleMovement paddleMovement;

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = new LevelManager(levelSpawner);

        levelSpawner.Init();
        gameLoop.Subscribe(levelManager,healthCount);
        scoreCount.Subscribe(levelManager);
        healthCount.Subscribe(ball);
        gameLoop.GameFinished += ResetLevel;
        ResetLevel();
    }

    private void ResetLevel()
    {
        ball.Init();
        paddleMovement.Init();
        levelManager.CreateLevel();
        healthCount.Init();
        scoreCount.Init();
    }

}
