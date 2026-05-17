using ShooterGame.Components;
using ShooterGame.UI;
using TMPro;
using UnityEngine;

public class NumberPopSpawner : MonoBehaviour
{
    [SerializeField] private NumberPopUp m_NumberPopUp;
    [SerializeField] private HealthComponent m_Health;
    [SerializeField] private Color m_DamageColor;
    [SerializeField] private Color m_HealColor;

    [SerializeField] private Vector3 m_SpawnOffset;
    
    private void Start()
    {
        m_Health.HealthDecreaseEvent += OnHealthDecrease;
        m_Health.HealthIncreaseEvent += OnHealthIncrease;
    }

    private void OnHealthIncrease(int amount)
    {
        NumberPopUp numPopUp = Instantiate(m_NumberPopUp, transform.position + m_SpawnOffset, transform.rotation);
        numPopUp.SetText(amount.ToString());
        numPopUp.SetColor(m_HealColor);
    }

    private void OnDestroy()
    {
        m_Health.HealthDecreaseEvent -= OnHealthDecrease;
    }
    
    private void OnHealthDecrease(int amount)
    {
        NumberPopUp numPopUp = Instantiate(m_NumberPopUp, transform.position + m_SpawnOffset, transform.rotation);
        numPopUp.SetText(amount.ToString());
        numPopUp.SetColor(m_DamageColor);
    }
    

}
