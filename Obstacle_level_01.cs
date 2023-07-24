using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private const string MethodName = "SpawnObstacleAtPointA";
    private const string MethodName1 = "SpawnObstacleAtPointB";
    public GameObject obstaclePrefab;
    public Transform pointA; // Renamed from groundSpawnPoint
    public Transform pointB; // Renamed from airSpawnPoint
    public float minInterval = 10f;
    public float maxInterval = 15f;
    public float obstacleSpawnX = 15f;
    private void Start()
    {
        InvokeRepeating(MethodName, Random.Range(minInterval, maxInterval), Random.Range(minInterval, maxInterval));
        InvokeRepeating(MethodName1, Random.Range(minInterval, maxInterval), Random.Range(minInterval, maxInterval));
    }
    private void SpawnObstacleAtPointA()
    {
        UnityEngine.Vector3 spawnPositionA = new(obstacleSpawnX, 2.7f, 0f);
        GameObject obstacleA = Instantiate(obstaclePrefab, spawnPositionA, UnityEngine.Quaternion.identity);
        obstacleA.GetComponent<Rigidbody>().velocity = new UnityEngine.Vector3(-5f, 0f);
    }
    private void SpawnObstacleAtPointB()
    {
        UnityEngine.Vector3 spawnPositionB = new(obstacleSpawnX, 0.9f, 0f);
        GameObject obstacleB = Instantiate(obstaclePrefab, spawnPositionB, UnityEngine.Quaternion.identity);
        obstacleB.GetComponent<Rigidbody>().velocity = new UnityEngine.Vector3(-5f, 0f);
    }
}