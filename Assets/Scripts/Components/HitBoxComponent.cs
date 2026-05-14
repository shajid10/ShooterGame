using System;
using Components;
using UnityEngine;

public class HitBoxComponent : MonoBehaviour
{
    [SerializeField] private int m_Damage;
    [SerializeField] private LayerMask  m_LayerMask;
    private HurtBoxComponent _target;
    private GameObject _other;
    
    public int Damage
    {
        get => m_Damage;
        private set => m_Damage = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_LayerMask == (m_LayerMask | (1 << other.gameObject.layer)))
        {
            _target = other.GetComponent<HurtBoxComponent>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_LayerMask == (m_LayerMask | (1 << other.gameObject.layer)))
        {
            _target = null;
        }
    }

    public void DealDamage()
    {
        if (_target)
        {
            _target.GetHurt(m_Damage);
        }
    }
}
