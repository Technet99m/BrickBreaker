using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public event Action BallFalled;

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidBody;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        BallFalled += Init;
    }

    public void Init()
    {
        transform.position = startPosition;
        rigidBody.velocity = new Vector2(Random.Range(-0.5f, 0.5f), 1).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out BottomZone zone))
            BallFalled?.Invoke();
    }
}
