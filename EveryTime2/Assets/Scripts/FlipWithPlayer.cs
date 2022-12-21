using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWithPlayer : MonoBehaviour
{
    void Awake()
    {
        if (data.type == GameType.Flipped)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
}