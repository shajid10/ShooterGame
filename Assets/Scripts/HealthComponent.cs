using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int m_Health;
    [SerializeField] private int m_MaxHealth;
    public event Action HealthChangedEvent;
    public event Action EnemyDeathEvent;

    public void ReduceHealth(int amount)
    {
        m_Health -= amount;
        HealthChangedEvent?.Invoke();
        if (m_Health <= 0)
        {
            EnemyDeathEvent?.Invoke();
        }
    }
    
    public void Heal(int amount)
    {
        m_Health += amount;
        HealthChangedEvent?.Invoke();
    }

    public int GetHealth() { return m_Health; }
    public int GetMaxHealth() { return m_MaxHealth; }
    public void SetMaxHealth(int value) => m_MaxHealth = value;
    public float GetHealthPercentage() { return (float)m_Health / m_MaxHealth; }
}
