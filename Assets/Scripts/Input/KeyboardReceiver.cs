using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardReceiver : InputReceiver
{
    public override float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }
}
