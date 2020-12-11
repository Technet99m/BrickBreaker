using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraBorder 
{
    public static float GetLeftBorder(this Camera cam)
    {
        return cam.ViewportToWorldPoint(Vector3.zero).x;
    }

    public static float GetRightBorder(this Camera cam)
    {
        return cam.ViewportToWorldPoint(Vector3.one).x;
    }

    public static float GetTopBorder(this Camera cam)
    {
        return cam.ViewportToWorldPoint(Vector3.one).y;
    }

    public static float GetBottomBorder(this Camera cam)
    {
        return cam.ViewportToWorldPoint(Vector3.zero).y;
    }
}
