using ScriptableObjects;
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
    
        [SerializeField] private TurretData m_TurretData;

        private void Start()
        {
            _gun = GetComponent<Gun>();
            _enemyDetector = GetComponentInChildren<EnemyDetector>();
        
            //_gun.SetDamage(m_TurretSO.m_Damage.Value);
            //m_TurretData.m_Damage.ValueChangedEvent += OnDamageValueChanged;
            //m_TurretData.m_Damage.Initialize();   
        }

        private void OnDamageValueChanged()
        {
            //_gun.SetDamage(m_TurretData.m_Damage.Value);
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
