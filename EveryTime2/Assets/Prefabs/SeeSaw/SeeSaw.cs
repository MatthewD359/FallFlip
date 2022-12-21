using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class SeeSaw : MonoBehaviour
{
    public LayerMask playerLayer;

    public float downSpeed;
    public float upSpeed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.OverlapBox(transform.position + new Vector3(0, transform.localScale.y / 2 + 0.1f, 0) * (transform.eulerAngles.z != 0 ? -1 : 1), new Vector2(transform.localScale.x + .1f, .1f), 0, playerLayer))
        {
            rb.velocity = new Vector2(0, -downSpeed);
        }
        else
            rb.velocity = new Vector2(0, upSpeed);
    }
}