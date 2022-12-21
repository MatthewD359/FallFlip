using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Layer0 : MonoBehaviour
{
    public TilemapRenderer tRenderer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //tRenderer.enabled = false;
            StartCoroutine(tRenderer.GetComponent<Fade>().FadeOut());
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //tRenderer.enabled = true;
            StartCoroutine(tRenderer.GetComponent<Fade>().FadeIn());
        }
    }
}