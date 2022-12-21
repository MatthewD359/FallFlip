using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class OpaqueOnLoad : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Tilemap>().color = new Color(GetComponent<Tilemap>().color.r, GetComponent<Tilemap>().color.g, GetComponent<Tilemap>().color.b, 1);
    }
}