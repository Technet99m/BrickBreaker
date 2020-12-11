using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private InputReceiver inputReceiver;

    [SerializeField]
    private float speed;

    public void Init()
    {
        transform.position = new Vector3(camera.transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * inputReceiver.GetHorizontalAxis() * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GetMinXPosition(), GetMaxXPosition()), transform.position.y, transform.position.z);
    }

    private float GetMinXPosition()
    {
        return camera.GetLeftBorder() + transform.localScale.x / 2;
    }

    private float GetMaxXPosition()
    {
        return camera.GetRightBorder() - transform.localScale.x / 2;
    }
}
