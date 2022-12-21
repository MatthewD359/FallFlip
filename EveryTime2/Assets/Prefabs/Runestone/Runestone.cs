using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runestone : MonoBehaviour
{
    public GameObject rune;
    [HideInInspector]
    public bool cached;
    public bool flipped;

    void Awake()
    {
        if (data.type == GameType.Flipped)
        {
            if (!flipped)
            {
                Destroy(rune);
                Destroy(gameObject);
            }
        }
        else
        {
            if (flipped)
            {
                Destroy(rune);
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        if (!GameController.runestones.Contains(gameObject.name))
        {
            cached = true;
            rune.GetComponent<Collectible>().cached = true;
            rune.GetComponent<Collectible>().targetObject = gameObject;
            rune.transform.position = transform.position;
        }
    }

    void Cache()
    {
        cached = true;
        GameController.runestones.Remove(gameObject.name);
    }
}