using ShooterGame.Player;
using ShooterGame.Weapons;
using Unity.Cinemachine;
using UnityEngine;

namespace ShooterGame.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float m_CamShakeIntensity = 0.3f;
    
        private CinemachineImpulseSource _impulseSource;
        private Gun _gun;

        private void Start()
        {
            _gun = Player.Player.Instance.GetGun();
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
}
