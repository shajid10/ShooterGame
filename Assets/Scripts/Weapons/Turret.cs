using System;
using ScriptableObjects;
using ShooterGame.Data;
using ShooterGame.ScriptableObjects;
using UnityEngine;

namespace ShooterGame.Weapons
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private float m_RotateSpeed = 10f;
    
        private Transform _currentTarget = null;
        private Gun _gun;
        private EnemyDetector _enemyDetector;
    
        [SerializeField] private UpgradeData m_TurretUpgradeData;

        private void Start()
        {
            _gun = GetComponent<Gun>();
            _enemyDetector = GetComponentInChildren<EnemyDetector>();
        
            _gun.SetDamage(m_TurretUpgradeData.m_Damage);
            m_TurretUpgradeData.UpgradeCompleteEvent += OnUpgradeComplete; 
        }

        private void OnDestroy()
        {
            m_TurretUpgradeData.UpgradeCompleteEvent -= OnUpgradeComplete;
        }

        private void OnUpgradeComplete()
        {
            _gun.SetDamage(m_TurretUpgradeData.m_Damage);
        }

        private void FixedUpdate()
        {
            _currentTarget = _enemyDetector.GetNearestEnemy();
            HandleShooting();
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
}
