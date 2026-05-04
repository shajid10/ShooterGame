using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public event EventHandler OnShoot;
    
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private Transform m_BulletSpawnPoint;
    [SerializeField] private float m_TimeInterval = 0.8f;
    [SerializeField] private ParticleSystem m_MuzzleFlash;
    
    private float _timeRemaining = 0f;
    private bool _isShooting = false;

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
        GameObject bulletInstance = Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
        m_MuzzleFlash.Play();
        OnShoot?.Invoke(this, EventArgs.Empty);
    }

    public void SetShooting(bool shooting) {
        _isShooting = shooting;
    }
}
