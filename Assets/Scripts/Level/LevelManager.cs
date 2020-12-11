using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    public event Action<BrickType> BrickDestroyed;
    public event Action AllBricksDestroyed;

    private LevelSpawner levelSpawner;
    private int blocksCount;

    public LevelManager(LevelSpawner levelSpawner)
    {
        this.levelSpawner = levelSpawner;
    }

    public void CreateLevel()
    {
        blocksCount = levelSpawner.SpawnLevel(OnBrickDestroyed);
    }

    private void OnBrickDestroyed(BrickType type)
    {
        BrickDestroyed?.Invoke(type);

        blocksCount--;
        if (blocksCount==0)
        {
            AllBricksDestroyed?.Invoke();
        }
    }
}
