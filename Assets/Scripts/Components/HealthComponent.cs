using System;
using UnityEngine;

namespace ShooterGame.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int m_Health;
        [SerializeField] private int m_MaxHealth;
        public event Action HealthChangedEvent;
        public event Action<int> HealthIncreaseEvent;
        public event Action<int> HealthDecreaseEvent;
        public event Action DeathEvent;

        private void Start()
        {
            HealthChangedEvent?.Invoke();
        }

        public void ReduceHealth(int amount)
        {
            m_Health -= amount;
            HealthChangedEvent?.Invoke();
            HealthDecreaseEvent?.Invoke(amount);
            if (m_Health <= 0)
            {
                DeathEvent?.Invoke();
            }
        }
    
        public void Heal(int amount)
        {
            m_Health = Mathf.Clamp(m_Health + amount, 0, m_MaxHealth);
            HealthChangedEvent?.Invoke();
            HealthIncreaseEvent?.Invoke(amount);
        }

        public int GetHealth() { return m_Health; }
        public int GetMaxHealth() { return m_MaxHealth; }
        public void SetMaxHealth(int value) => m_MaxHealth = value;
        public float GetHealthPercentage() { return (float)m_Health / m_MaxHealth; }
    }
}
