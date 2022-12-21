using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameType { Normal, Flipped};

public class PlayButton : MonoBehaviour
{
    public string level;
    public GameType type;

    public void Click()
    {
        SceneManager.LoadScene(level);
        data.type = type;
    }
}