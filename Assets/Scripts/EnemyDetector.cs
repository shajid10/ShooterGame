using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{    
    [SerializeField] private float m_DetectionRadius = 5f;
    private SphereCollider _detectionCollider;

    private readonly List<Transform> _enemiesInRange = new();

    private Transform _currentTarget;

    private void Start()
    {
        _detectionCollider = GetComponent<SphereCollider>();
        _detectionCollider.isTrigger = true;
        _detectionCollider.radius = m_DetectionRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        print(other);

        _enemiesInRange.Add(other.transform);
    }

    // TODO: Fix player shooting even when enemy is dead
    private void OnTriggerExit(Collider other)
    {
        print(other);
        if (!other.CompareTag("Enemy")) return;
        print(other);

        _enemiesInRange.Remove(other.transform);
        
        print(_currentTarget);
        if (_currentTarget != null && _currentTarget.gameObject == other.gameObject)
        {
            _currentTarget = null;
        }
    }

    private void FixedUpdate()
    {
        FindNearestEnemy();
    }

    private void FindNearestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;
        for (int i = _enemiesInRange.Count - 1; i >= 0; i--)
        {
            Transform enemy = _enemiesInRange[i];

            if (!enemy)
            {
                _enemiesInRange.RemoveAt(i);
                continue;
            }

            if (enemy.TryGetComponent(out Enemy enemyObject) && !enemyObject.IsAlive())
            {
                _enemiesInRange.RemoveAt(i);
                continue;
            }

            float distance = Vector3.Distance(transform.position, enemy.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        _currentTarget = nearestEnemy;
    }

    public Transform GetNearestEnemy()
    {
        return _currentTarget;
    }
}
