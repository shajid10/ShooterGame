using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthComponent m_HealthComponent;
        [SerializeField] private Image m_FillImage;
        [SerializeField] private float m_FillDuration;

        private void Start()
        {
            m_HealthComponent.OnHealthChanged += HealthComponentOnOnHealthChanged;
        }

        private void HealthComponentOnOnHealthChanged(object sender, EventArgs e)
        {
            if (m_FillImage != null)
                m_FillImage.DOFillAmount(m_HealthComponent.GetHealthPercentage(), m_FillDuration).SetEase(Ease.InOutSine).SetLink(gameObject);
        }
    }
}
