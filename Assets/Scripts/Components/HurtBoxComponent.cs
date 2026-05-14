using System.Collections;
using ShooterGame.Components;
using UnityEngine;

namespace Components
{
    public class HurtBoxComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent m_Health;

        public void GetHurt(int damage)
        {
            m_Health.ReduceHealth(damage);
        }
    }
}
