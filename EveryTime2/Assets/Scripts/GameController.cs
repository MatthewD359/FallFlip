using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameController
{
    public static Vector3 playerSpawn;
    public static Vector3 flippedPlayerSpawn;
    public static bool useSpawn;

    public static bool logFPS;

    public static List<string> loadedScenes;
    public static List<string> runestones;

    static GameController()
    {
        if (data.type == GameType.Flipped)
        {
            playerSpawn = flippedPlayerSpawn;
        }

        SceneManager.sceneLoaded += OnSceneLoad;

        loadedScenes = new List<string>();
        runestones = new List<string>();

        Application.targetFrameRate = 60;
        OnSceneLoad(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    static void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (data.inLevel)
            GameObject.FindGameObjectWithTag("ScreenCover").GetComponent<Fade>().StartCoroutine(GameObject.FindGameObjectWithTag("ScreenCover").GetComponent<Fade>().FadeOut());

        data.paused = false;
        Time.timeScale = 1;

        if (!loadedScenes.Contains(SceneManager.GetActiveScene().name))
        {
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Checkpoint"))
            {
                runestones.Add(i.name);
            }
            loadedScenes.Add(SceneManager.GetActiveScene().name);
        }

        if (useSpawn && data.inLevel)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn;
        }
        else useSpawn = true;
    }
}