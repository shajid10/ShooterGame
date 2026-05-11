using System;
using UnityEngine;

namespace ShooterGame.Weapons
{
    public class Gun : MonoBehaviour
    {
        public event Action ShootEvent;
    
        [SerializeField] private Bullet m_BulletPrefab;
        [SerializeField] private Transform m_BulletSpawnPoint;
        [SerializeField] private float m_TimeInterval = 0.8f;
        [SerializeField] private ParticleSystem m_MuzzleFlash;
    
        private float _timeRemaining = 0f;
        private bool _isShooting = false;

        private int _damage = 0;
    
        private void Start() {
            _timeRemaining = m_TimeInterval;
        }

        private void Update() {
            if (_isShooting) {
                if (_timeRemaining > 0) {
                    _timeRemaining -= Time.deltaTime;
                } else {
                    Shoot();
                    _timeRemaining = m_TimeInterval;
                }
            }
        }

        private void Shoot() {
            Bullet bulletInstance = Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
            bulletInstance.SetBulletDamage(_damage);
            print(_damage);
            m_MuzzleFlash.Play();
            ShootEvent?.Invoke();
        }

        public void SetShooting(bool shooting) {
            _isShooting = shooting;
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
    }
}
