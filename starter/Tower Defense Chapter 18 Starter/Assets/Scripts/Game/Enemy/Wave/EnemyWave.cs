using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyWave
{
    // path to follow
    public int pathIndex;
    // starts spawn timer
    public float startSpawnTimeInSeconds;
    // there is 1 second between spawns
    public float timeBetweenSpawnsInSeconds = 1f;
    // enemy list
    public List<GameObject> listOfEnemies = new List<GameObject>();
}