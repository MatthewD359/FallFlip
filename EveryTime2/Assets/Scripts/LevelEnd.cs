using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            data.inLevel = false;
            StartCoroutine(GameObject.FindGameObjectWithTag("ScreenCover").GetComponent<Fade>().FadeIn("Title"));
        }
    }
}