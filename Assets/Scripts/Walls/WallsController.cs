using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    [SerializeField]
    private Wall leftWall, rightWall, topWall;
    [SerializeField]
    private BottomZone bottomZone;

    private float colliderWidth = 0.1f;

    private void Awake()
    {
        var cam = Camera.main;
        leftWall.transform.position = new Vector3(cam.GetLeftBorder(),cam.transform.position.y, 0);
        rightWall.transform.position = new Vector3(cam.GetRightBorder(),cam.transform.position.y, 0);
        topWall.transform.position = new Vector3(cam.transform.position.x, cam.GetTopBorder(), 0);
        bottomZone.transform.position = new Vector3(cam.transform.position.x, cam.GetBottomBorder(), 0);

        leftWall.SetSize(colliderWidth, cam.GetTopBorder() - cam.GetBottomBorder());
        rightWall.SetSize(colliderWidth, cam.GetTopBorder() - cam.GetBottomBorder());
        topWall.SetSize(cam.GetRightBorder() - cam.GetLeftBorder(), colliderWidth);
        bottomZone.SetSize(cam.GetRightBorder() - cam.GetLeftBorder(), colliderWidth);
    }
}
