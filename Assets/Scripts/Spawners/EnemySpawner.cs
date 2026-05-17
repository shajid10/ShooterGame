using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ShooterGame.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private bool m_EnableSpawning = true;
        [SerializeField] private List<Enemy> m_EnemyPrefabs;
        [SerializeField] private List<Transform> m_SpawnPoints;

        [SerializeField] private float m_TimeInterval = 10f;
    
        
        private float _timeRemaining = 0f;
        

        private void Start() {
            _timeRemaining = m_TimeInterval;
        }

        private void FixedUpdate() {
            if (!m_EnableSpawning) return;
            if (_timeRemaining > 0) {
                _timeRemaining -= Time.deltaTime;
            } else {
                SpawnEnemy();
                _timeRemaining = m_TimeInterval;
            }
        }

        [Button]
        private void SpawnEnemy() {
            int selectedSpawnPointIndex = Random.Range(0, m_SpawnPoints.Count);
            Transform selectedSpawnPoint = m_SpawnPoints[selectedSpawnPointIndex];

            int enemyType =  Random.Range(0, 2);
            Instantiate(m_EnemyPrefabs[enemyType], selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }
}
