using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music music;

    void Awake()
    {
        if (music == null)
        {
            music = this;
        }
        else Destroy(gameObject);
    }

    void Update()
    {
        GetComponent<AudioSource>().volume = data.paused ? .25f : 1;
    }
}