using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings",order = 51)]
public class LevelSettings : ScriptableObject
{
    [SerializeField, Tooltip("Initial vertical size of grid")]
    private int difficulty;

    [SerializeField, Range(0, 1), Tooltip("Defines how sharp can level shape change. 0 - Flat, 1 - pretty sharp")]
    private float sharpness;

    [SerializeField, Tooltip("Defines how many block are in row")]
    private int blockCount;

    public float Sharpness => Mathf.Clamp01(sharpness);
    public int Difficulty => difficulty;
    public int BlockCount => blockCount;
}
