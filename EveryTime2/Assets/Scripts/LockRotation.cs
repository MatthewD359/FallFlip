using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    Vector3 rotation;

    void Awake()
    {
        rotation = transform.eulerAngles;
    }

    void Update()
    {
        transform.eulerAngles = rotation;
    }
}