using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLog : MonoBehaviour
{
    void Update()
    {
        if (transform.eulerAngles.z > 87)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
}