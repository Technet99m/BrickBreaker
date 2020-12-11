using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Wall : MonoBehaviour
{

    public virtual void SetSize(float x,float y)
    {
        GetComponent<BoxCollider2D>().size = new Vector2(x,y);
    }
}
