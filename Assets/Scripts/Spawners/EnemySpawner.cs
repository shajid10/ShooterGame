using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy m_EnemyPrefab;
        [SerializeField] private List<Transform> m_SpawnPoints;

        [SerializeField] private float m_TimeInterval = 10f;
    
        private float _timeRemaining = 0f;

        private void Start() {
            _timeRemaining = m_TimeInterval;
        }

        private void FixedUpdate() {
            if (_timeRemaining > 0) {
                _timeRemaining -= Time.deltaTime;
            } else {
                SpawnEnemy();
                _timeRemaining = m_TimeInterval;
            }
        }

        private void SpawnEnemy() {
            int selectedSpawnPointIndex = Random.Range(0, m_SpawnPoints.Count);
            Transform selectedSpawnPoint = m_SpawnPoints[selectedSpawnPointIndex];

            Instantiate(m_EnemyPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }
}
