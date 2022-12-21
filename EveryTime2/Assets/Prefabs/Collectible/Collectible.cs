using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    Vector3 target;
    Vector3 start;
    [HideInInspector]
    public GameObject targetObject;

    public float speed;
    [HideInInspector]
    public bool cached;

    void Awake()
    {
        start = transform.position;
        target = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetObject == null ? target : targetObject.transform.position, speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !cached)
        {
            targetObject = col.gameObject;
            col.gameObject.GetComponent<PlayerDeath>().Checkpoint += Cache;
        }
        if (cached && col.gameObject == targetObject)
        {
            Destroy(gameObject);
        }
    }

    void Cache(GameObject stone)
    {
        if (!cached && stone.GetComponent<Runestone>().rune == gameObject)
        {
            targetObject.GetComponent<PlayerDeath>().Checkpoint -= Cache;
            targetObject = stone;
            stone.SendMessage("Cache");
            cached = true;
        }
    }
}