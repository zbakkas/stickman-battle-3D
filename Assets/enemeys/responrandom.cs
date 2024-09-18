using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responrandom : MonoBehaviour
{

    public GameObject[] enemy;
    public float [] pric = { 0.2f, 0.5f, 0.2f, 0.1f };
    int[] numEnemries;
    private void Start()
    {
        int totalEnemies = 10;

        numEnemries = new int[enemy.Length];
        for (int i = 0; i < enemy.LongLength; i++)
        {
            numEnemries[i] = Mathf.RoundToInt(totalEnemies * pric[i]);
        }


        for (int i = 0; i < enemy.LongLength; i++)
        {
            SpawnEnemies(enemy[i], numEnemries[i]);
        }
    }

    private void SpawnEnemies(GameObject enemyPrefab, int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            // Instantiate the enemy prefab at a random position
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
