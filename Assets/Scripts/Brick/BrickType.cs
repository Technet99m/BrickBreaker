using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BrickType", menuName = "Brick Type", order = 53)]
public class BrickType : ScriptableObject
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private int score;

    public Color Color => color;
    public int Score => score;
}
