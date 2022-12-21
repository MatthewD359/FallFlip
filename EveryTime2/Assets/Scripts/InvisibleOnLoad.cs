using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapRenderer))]
public class InvisibleOnLoad : MonoBehaviour
{
    void Awake()
    {
        GetComponent<TilemapRenderer>().enabled = false;
    }
}