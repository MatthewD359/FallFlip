using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class data
{
    public static GameType type;
    public static bool running;
    static InputMaster input;

    static data()
    {
        input = new InputMaster();
        input.Enable();
        input.Player.Run.performed += ctx => running = true;
        input.Player.Run.canceled += ctx => running = false;
    }
}