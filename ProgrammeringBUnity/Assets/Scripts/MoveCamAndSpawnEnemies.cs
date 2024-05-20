using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamAndSpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] cams;
    bool[] currentStateCam;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] Transform enemySpawnLocation;
    [SerializeField] Transform enemySpawnLocation2;
    bool hasSpawnedEnemies = false;


    private void Start()
    {
        currentStateCam = new bool[cams.Length];
        currentStateCam[0] = true;

        for (int i = 1; i < currentStateCam.Length; i++)
        {
            currentStateCam[i] = false;
        }
    }

    public void MoveCam(int touchedPlayer)
    {

        for (int i = 0; i < cams.Length; i++)
        {
            if(i == touchedPlayer)
            {
                if(i == 2 && !hasSpawnedEnemies)
                {
                    Instantiate(enemyPrefab, enemySpawnLocation);
                    Instantiate(enemyPrefab2, enemySpawnLocation2);
                    hasSpawnedEnemies = true;
                }
                currentStateCam[i] = !currentStateCam[i];
                cams[i].SetActive(currentStateCam[i]);
            }
        }

    }
}
