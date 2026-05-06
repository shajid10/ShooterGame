using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private Image m_FillImage;
        [SerializeField] private int m_ScoreThreshold;
        
        private GemCollector _gemCollector;

        private void Start()
        {
            _gemCollector = Player.Instance.GetComponent<GemCollector>();
            _gemCollector.OnGemCollected += GemCollectorOnOnGemCollected;
        }

        private void GemCollectorOnOnGemCollected(object sender, EventArgs e)
        {
            long gemCount = _gemCollector.GetGemCount();
            float fillPercentage = (gemCount%m_ScoreThreshold) / (float)m_ScoreThreshold;
            if (m_FillImage)
                m_FillImage.DOFillAmount(fillPercentage, 0.5f).SetEase(Ease.InOutSine).SetLink(gameObject);
        }
    }
}
