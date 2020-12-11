using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private LevelSettings levelSettings;

    [SerializeField]
    private Brick brickPrefab;

    [SerializeField]
    private float biasMod;
    

    private float sceneWidth;

    private List<Transform> blocks = new List<Transform>();

    public void Init()
    {
        sceneWidth = camera.GetRightBorder() - camera.GetLeftBorder();
    }


    public int SpawnLevel(Action<BrickType> onBrickDestroyed)
    {
        ClearLevel();

        var relief = GenerateRelief();

        return SpawnBlocks(relief, onBrickDestroyed);
    }

    private void ClearLevel()
    {
        if (blocks.Count > 0)
        {
            blocks.ForEach(x => Destroy(x.gameObject));
            blocks.Clear();
        }
    }

    private int[] GenerateRelief()
    {
        int[] columns = new int[levelSettings.BlockCount];
        columns[0] = levelSettings.Difficulty;
        columns[columns.Length - 1] = levelSettings.Difficulty;

        CalculateColumnsLenght(columns, 0, columns.Length - 1);
        return columns;
    }

    private int SpawnBlocks(int[] columns, Action<BrickType> onBrickDestroyed)
    {
        int blocksTotal = 0;
        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i]; j++)
            {
                var block = Instantiate(brickPrefab);
                block.Init(onBrickDestroyed);
                var blockTransform = block.transform;
                blockTransform.localScale *= sceneWidth / levelSettings.BlockCount;
                blockTransform.position = new Vector3(camera.GetLeftBorder() + i * blockTransform.localScale.x, camera.GetTopBorder() - j * blockTransform.localScale.y);
                blocks.Add(blockTransform);
                blocksTotal++;
            }
        }
        return blocksTotal;
    }

    private void CalculateColumnsLenght(int[] columns, int a, int b)
    {
        if (b - a == 1)
            return;
        if ((a + b) / 2f % 1 == 0)
        {
            columns[(a + b) / 2] = Clamp(Mathf.RoundToInt((columns[a] + columns[b]) / 2f + Bias(b - a)));
            CalculateColumnsLenght(columns, a, (a + b) / 2);
            CalculateColumnsLenght(columns, (a + b) / 2, b);
        }
        else
        {
            int i = Mathf.CeilToInt((a + b) / 2f);
            int j = Mathf.FloorToInt((a + b) / 2f);
            columns[i] = Clamp(Mathf.RoundToInt((columns[a] + columns[b]) / 2f + Bias(b - a)));
            columns[j] = columns[i];
            CalculateColumnsLenght(columns, a, j);
            CalculateColumnsLenght(columns, i, b);
        }
    }

    private float Bias(int distance) => (Random.value - 0.5f) * 2 * levelSettings.Sharpness * biasMod * distance / levelSettings.BlockCount;
    private int Clamp(int value) => Mathf.Clamp(value, Mathf.CeilToInt(levelSettings.Difficulty/2f), Mathf.FloorToInt(levelSettings.Difficulty *1.5f));
}
