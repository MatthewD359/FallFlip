using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Swingin : MonoBehaviour
{
    Rigidbody2D rb;

    public float angle;
    public float speed;
    public float offset;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(angle * Mathf.Sin(speed * (Time.time + offset)));
    }
}