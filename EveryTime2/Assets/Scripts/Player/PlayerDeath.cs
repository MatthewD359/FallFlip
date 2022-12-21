using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Vector3 spawnPoint;

    public Action<GameObject> Checkpoint;

    void Die()
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("ScreenCover").GetComponent<Fade>().FadeIn(SceneManager.GetActiveScene().name));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Checkpoint")
        {
            Checkpoint?.Invoke(col.gameObject);
            GameController.playerSpawn = col.gameObject.transform.position;
        }
    }
}