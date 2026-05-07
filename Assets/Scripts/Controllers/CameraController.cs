using System;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_CamShakeIntensity = 0.3f;
    
    private CinemachineImpulseSource _impulseSource;
    private Gun _gun;

    private void Start()
    {
        _gun = Player.Instance.GetGun();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _gun.ShootEvent += OnGunShoot;
        
        _impulseSource.DefaultVelocity = Vector3.one * m_CamShakeIntensity;
    }
    private void OnDisable()
    {
        _gun.ShootEvent -= OnGunShoot;
    }

    private void OnGunShoot()
    {
        _impulseSource.GenerateImpulse();
    }

}
