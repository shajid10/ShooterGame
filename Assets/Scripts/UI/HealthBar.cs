using ShooterGame.Components;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthComponent m_HealthComponent;
        [SerializeField] private Image m_FillImage;
        [SerializeField] private float m_FillDuration;
        
        [OnValueChanged("OnFillColorChanged")]
        [SerializeField] private Color m_FillColor = Color.red;

        private void Start()
        {
            m_HealthComponent.HealthChangedEvent += OnHealthChanged;
            
            m_FillImage.color = m_FillColor;
        }

        private void OnDestroy()
        {
            m_HealthComponent.HealthChangedEvent -= OnHealthChanged;
        }
        
        private void OnHealthChanged()
        {
            if (m_HealthComponent.GetHealth() <= 0) gameObject.SetActive(false);
            if (m_FillImage)
                m_FillImage.DOFillAmount(m_HealthComponent.GetHealthPercentage(), m_FillDuration).SetEase(Ease.InOutSine).SetLink(gameObject);
        }

        private void OnFillColorChanged()
        {
            m_FillImage.color = m_FillColor;
        }
    }
}
