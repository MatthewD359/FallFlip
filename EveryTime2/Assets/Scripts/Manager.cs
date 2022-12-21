using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Player player;

    public Action Flip;
    public Action NotFlip;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        
    }

    void Start()
    {
        if (player.GetComponent<PlayerMovement>().upsideDown)
        {
            Flip?.Invoke();
        }
        else NotFlip?.Invoke();
    }
}