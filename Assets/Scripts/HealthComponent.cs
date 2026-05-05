using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int m_Health;
    [SerializeField] private int m_MaxHealth;
    public event EventHandler OnHealthChanged;
    public event EventHandler OnDeath;

    public void ReduceHealth(int amount)
    {
        m_Health -= amount;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
        if (m_Health <= 0)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public void Heal(int amount)
    {
        m_Health += amount;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetHealth() { return m_Health; }
    public int GetMaxHealth() { return m_MaxHealth; }
    public float GetHealthPercentage() { return (float)m_Health / m_MaxHealth; }
}
