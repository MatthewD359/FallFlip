using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    InputMaster input;
    public GameObject menuController;

    void Awake()
    {
        input = new InputMaster();
        input.UI.Pause.started += ctx => PauseButtonPressed();
    }

    void PauseButtonPressed()
    {
        if (data.paused)
        {
            Resume();
        } 
        else Pause();
    }

    void Pause()
    {
        menuController.GetComponent<Animator>().SetTrigger("LoadIn");
        Time.timeScale = 0;
        //menuController.SetActive(true);
        data.paused = true;
        
    }

    void Resume()
    {
        Time.timeScale = 1;
        //menuController.SetActive(false);
        data.paused = false;
        menuController.GetComponent<Animator>().SetTrigger("LoadOut");
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}