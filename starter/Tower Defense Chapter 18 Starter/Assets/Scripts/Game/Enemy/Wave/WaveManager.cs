﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    
    public static WaveManager Instance;
    
    public List<EnemyWave> enemyWaves = new List<EnemyWave>();
    
    private float elapsedTime = 0f;
    
    private EnemyWave activeWave;
    
    private float spawnCounter = 0f;
    
    private List<EnemyWave> activatedWaves = new List<EnemyWave>();
    
    // sets instance 
    void Awake()
    {
        Instance = this;
    }
    
    // searches for the waves then updates as needed for next wave 
    void Update()
    {
        elapsedTime += Time.deltaTime;

        SearchForWave();
        UpdateActiveWave();
    }
    private void SearchForWave()
    {
    
        foreach (EnemyWave enemyWave in enemyWaves)
        {
    
            if (!activatedWaves.Contains(enemyWave) && enemyWave.startSpawnTimeInSeconds <= elapsedTime)
            {
                // Activate next wave
    
                activeWave = enemyWave;
                activatedWaves.Add(enemyWave);
                spawnCounter = 0f;
                GameManager.Instance.waveNumber++;
                UIManager.Instance.ShowCenterWindow("Wave " + GameManager.Instance.waveNumber);

                break;
            }
        }
    }
  
    private void UpdateActiveWave()
    {
       
        if (activeWave != null)
        {
            spawnCounter += Time.deltaTime;
            
            // when wave is over
            if (spawnCounter >= activeWave.timeBetweenSpawnsInSeconds)
            {
                spawnCounter = 0f;

                // if wave is not over
                if (activeWave.listOfEnemies.Count != 0)
                {
                   
                    GameObject enemy = (GameObject)Instantiate(activeWave.listOfEnemies[0], WayPointManager.Instance.GetSpawnPosition(activeWave.pathIndex), Quaternion.identity);
                    
                    enemy.GetComponent<Enemy>().pathIndex = activeWave.pathIndex;
                    
                    activeWave.listOfEnemies.RemoveAt(0);
                }
                else
                {
                    
                    activeWave = null;
                    
                    if (activatedWaves.Count == enemyWaves.Count)
                    {
                       GameManager.Instance.enemySpawningOver = true;
                        // All waves are over
                    }
                }
            }
        }
    }

    public void StopSpawning()
    {
        elapsedTime = 0;
        spawnCounter = 0;
        activeWave = null;
        activatedWaves.Clear();

        enabled = false;
    }
}