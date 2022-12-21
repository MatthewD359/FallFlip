using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    Tilemap tilemap;
    SpriteRenderer spriteRenderer;

    public float speed;
    public float max;

    void Awake()
    {
        if (GetComponent<Tilemap>() != null)
            tilemap = GetComponent<Tilemap>();
        if (GetComponent<SpriteRenderer>() != null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [ContextMenu("Fade In")]
    void TestIn()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float a = 0;
        while (a < max)
        {
            a += speed;
            if (a > max)
                a = max;

            if (tilemap != null)
                tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, a);
            if (spriteRenderer != null)
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a);
            yield return null;
        }
        yield break;
    }

    public IEnumerator FadeIn(string scene)
    {
        float a = 0;
        while (a < max)
        {
            a += speed;
            if (a > max)
                a = max;

            if (tilemap != null)
                tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, a);
            if (spriteRenderer != null)
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a);
            yield return null;
        }
        SceneManager.LoadScene(scene);
        yield break;
    }

    [ContextMenu("Fade Out")]
    void TestOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        float a = 1;
        while (a > 0)
        {
            a -= speed;
            if (tilemap != null)
                tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, a);
            if (spriteRenderer != null)
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a);
            yield return null;
        }
        yield break;
    }
}