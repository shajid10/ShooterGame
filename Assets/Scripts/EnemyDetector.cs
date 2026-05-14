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

        _enemiesInRange.Add(other.transform);
    }

    // TODO: Fix player shooting even when enemy is dead
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        _enemiesInRange.Remove(other.transform);

        if (_currentTarget == other.transform)
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

        // Cleanup + nearest search
        for (int i = _enemiesInRange.Count - 1; i >= 0; i--)
        {
            if (!_enemiesInRange[i])
            {
                _enemiesInRange.RemoveAt(i);
                continue;
            }

            float distance = Vector3.Distance(
                transform.position,
                _enemiesInRange[i].position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = _enemiesInRange[i];
            }
        }

        _currentTarget = nearestEnemy;
    }

    public Transform GetNearestEnemy()
    {
        return _currentTarget;
    }
}
