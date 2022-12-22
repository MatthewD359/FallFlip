using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Vector3 playerSpawn;
    public Vector3 flippedPlayerSpawn;
    public bool useSpawn;

    void Awake()
    {
        GameController.playerSpawn = playerSpawn;
        GameController.flippedPlayerSpawn = flippedPlayerSpawn;
        GameController.useSpawn = useSpawn;
        data.inLevel = true;
    }
}