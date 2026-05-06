using System;
using UnityEngine;
using UnityEngine.XR;

public class Turret : MonoBehaviour
{
    [SerializeField] private float m_RotateSpeed = 10f;
    [SerializeField] private float m_DetectionRadius = 3f;
    
    private Transform _currentTarget = null;
    private Gun _gun;

    private void Start()
    {
        _gun = GetComponent<Gun>();
    }

    private void FixedUpdate()
    {
        FindNearestEnemy();
        HandleShooting();
    }
    
    private void FindNearestEnemy() {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_DetectionRadius);

        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            if (!hit.CompareTag("Enemy")) continue;
            float distance = Vector3.Distance(transform.position, hit.transform.position);

            if (!(distance < closestDistance)) continue;
            _currentTarget = hit.transform;
            closestDistance = distance;
        }
    }

    private void HandleShooting() {
        if (_currentTarget) {
            _gun.SetShooting(true);

            Vector3 direction = _currentTarget.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * m_RotateSpeed);
        } else {
            _gun.SetShooting(false);
        }
    }
}
