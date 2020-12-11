using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomZone : Wall
{
    public override void SetSize(float x, float y)
    {
        base.SetSize(x, y);
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
