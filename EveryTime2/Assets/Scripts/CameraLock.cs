using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    Transform player;
    [SerializeField] float yValue;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position = player.position;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, yValue);
    }
}