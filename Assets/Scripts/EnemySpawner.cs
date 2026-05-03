using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private float timeInterval = 10f;
    [SerializeField] private float timeRemaining = 0f;

    private void Start() {
        timeRemaining = timeInterval;
    }

    private void FixedUpdate() {
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        } else {
            SpawnEnemy();
            timeRemaining = timeInterval;
        }
    }

    private void SpawnEnemy() {
        int selectedSpawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform selectedSpawnPoint = spawnPoints[selectedSpawnPointIndex];

        GameObject spawnedEnemy = Instantiate(enemyPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }
}
