using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] topObstacles;
    public GameObject[] bottomObtacles;

    public Transform topSpawnerPosition;
    public Transform bottomSpawnerPosition;

    public float spawnRate = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawner), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawner));   
    }

    public void Spawner()
    {
        int randomTopObstacle = Random.Range(0, topObstacles.Length);
        GameObject topObtacle = Instantiate(topObstacles[randomTopObstacle], topSpawnerPosition.position, Quaternion.identity);

        int randomBottomObtacle = Random.Range(0, bottomObtacles.Length);
        GameObject bottomObtacle = Instantiate(bottomObtacles[randomBottomObtacle], bottomSpawnerPosition.position, Quaternion.identity);
    }
}
