using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneDisplay : MonoBehaviour
{
    public string runestone;
    public Image image;
    public PlayButton playButton;

    void Awake()
    {
        if (GameController.loadedScenes.Contains(playButton.level))
            image.color = GameController.runestones.Contains(runestone) && GameController.loadedScenes.Contains(playButton.level) ? Color.white : Color.yellow;
        else image.color = Color.white;
    }
}