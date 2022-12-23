using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : ScriptableObject
{
    public static GameType type;
    public static bool running;
    static InputMaster input;
    public static bool inLevel = false;
    public static bool paused = false;

    public static List<string> runestones;

    static data()
    {
        input = new InputMaster();
        input.Enable();
        input.Player.Run.performed += ctx => running = true;
        input.Player.Run.canceled += ctx => running = false;

        // List Runestones
        runestones = new List<string>();
        runestones.Add("Runestone_Autumn");
        runestones.Add("Runestone_Autumn (1)");
        runestones.Add("Runestone_Autumn (2)");
        runestones.Add("Runestone_Autumn (3)");
        runestones.Add("Runestone_Autumn (4)");
        runestones.Add("Runestone_Autumn (5)");
        runestones.Add("Runestone_Autumn (6)");
        runestones.Add("Runestone_Autumn (7)");
        runestones.Add("Runestone_Autumn (8)");
        runestones.Add("Runestone_Autumn_Flip");
        runestones.Add("Runestone_Autumn_Flip (1)");
        runestones.Add("Runestone_Autumn_Flip (2)");
        runestones.Add("Runestone_Autumn_Flip (3)");
        runestones.Add("Runestone_Autumn_Flip (4)");
        runestones.Add("Runestone_Autumn_Flip (5)");
        runestones.Add("Runestone_Autumn_Flip (6)");
        runestones.Add("Runestone_Autumn_Flip (7)");
        runestones.Add("Runestone_Autumn_Flip (8)");
    }
}