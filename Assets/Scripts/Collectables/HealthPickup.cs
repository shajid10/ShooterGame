using ShooterGame.Components;
using UnityEngine;
using DG.Tweening;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int m_HealAmount = 40;

    private void Start()
    {
        transform.DOMoveY(0.8f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthComponent healthComponent = other.GetComponent<HealthComponent>();
            if (healthComponent)
            {
                healthComponent.Heal(m_HealAmount);
                Destroy(gameObject);
            }
        }
    }
}
