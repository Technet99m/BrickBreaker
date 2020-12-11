using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BrickTypesList", menuName = "Brick Types List", order = 52)]
public class BrickTypesList : ScriptableObject
{
    [SerializeField]
    private List<BrickType> types;

    public IReadOnlyList<BrickType> Types => types;
}
