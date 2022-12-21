using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    Rigidbody2D rb;
    public float xSpeed;
    public float xMagnitude;
    public float ySpeed;
    public float yMagnitude;
    public LayerMask groundLayer;
    float timeOffset = 0;
    Vector3 startPosition;
    public float offsetTime;
    bool moving = false;
    public GameObject synced;
    [HideInInspector]
    public bool cleared;

    public bool flying;
    public Vector2 flyingSpeed;
    public float flyingOffset;
    public float flyingHeight = 3;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        if (synced == null)
            StartCoroutine(Respawn());
        else moving = true;
    }

    void Update()
    {
        if (Physics2D.OverlapBox(transform.position, new Vector2(transform.localScale.x, transform.localScale.y), 0, groundLayer) && Physics2D.OverlapBoxAll(transform.position, new Vector2(transform.localScale.x, transform.localScale.y), 0, groundLayer).Length > 1)
            StartCoroutine(Respawn());

        UpdateAnimations();
    }

    void FixedUpdate()
    {
        if (moving)
        {
            float time = Time.time - timeOffset;
            if (!flying)
                rb.velocity = new Vector2(Mathf.Cos(xSpeed * time) * xMagnitude, yMagnitude * -Mathf.Cos(ySpeed * time) - yMagnitude);
            else rb.velocity = new Vector2(flyingSpeed.x, flyingHeight * Mathf.Sin(flyingSpeed.y * time) + flyingOffset);
        }
        else rb.velocity = Vector2.zero;
    }

    void UpdateAnimations()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y);
        }
        else transform.localScale = new Vector3(1, transform.localScale.y);
    }

    IEnumerator Respawn()
    {
        moving = false;
        transform.position = startPosition;
        cleared = true;
        if (synced == null)
        {
            yield return new WaitForSeconds(offsetTime);
        }
        else
        {
            if (synced.GetComponent<FallingLeaf>().cleared)
            {

            }
            else
            {
                while (!synced.GetComponent<FallingLeaf>().cleared)
                    yield return null;
            }
        }
        timeOffset = Time.time;
        moving = true;
        yield return new WaitForSeconds(.5f);
        cleared = false;
    }
}