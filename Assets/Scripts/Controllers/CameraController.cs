using System;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] Vector3 m_Offset = new Vector3(0, 8, -8);
    [SerializeField] private float m_CamFollowSpeed;
    [SerializeField] private float m_CamShakeIntensity = 0.3f;

    private Tween _camTweener;
    
    private Gun _gun;

    private void Start()
    {
        _gun = Player.Instance.GetGun();
        _gun.OnShoot += GunOnOnShoot;
    }

    private void GunOnOnShoot(object sender, EventArgs e)
    {
        CameraShake();
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, m_Target.position + m_Offset, Time.deltaTime * m_CamFollowSpeed);
        _camTweener?.Kill();
        _camTweener = transform.DOMove(m_Target.position + m_Offset, m_CamFollowSpeed).SetSpeedBased().SetLink(gameObject);
    }

    private void CameraShake()
    {
        transform.DOShakePosition(0.2f, m_CamShakeIntensity, 3);
        transform.DOShakeRotation(0.2f, m_CamShakeIntensity, 3);
    }
}
