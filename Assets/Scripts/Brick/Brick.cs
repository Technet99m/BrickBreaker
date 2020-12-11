using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BrickTypesList blockTypes;

    private BrickType type;

    private Action<BrickType> BrickDestroyed;

    public void Init(Action<BrickType> onDestroyed)
    {
        type = blockTypes.Types[Random.Range(0, blockTypes.Types.Count)];
        spriteRenderer.color = type.Color;
        BrickDestroyed += onDestroyed;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ball ball))
        {
            gameObject.SetActive(false);
            BrickDestroyed?.Invoke(type);
        }
    }
}
