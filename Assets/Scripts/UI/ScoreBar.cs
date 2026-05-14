using System;
using DG.Tweening;
using ShooterGame.Player;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame.UI
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private Image m_FillImage;
        [SerializeField] private int m_ScoreThreshold;
        
        [SerializeField] private PlayerData m_Player;
        private GemCollector _gemCollector;

        private Tweener _barTweener;
        
        public static event Action ScoreBarCompletedEvent;
        
        private long m_Sum = 0;

        private void Start()
        {
            CurrencyManager.CurrencyIncreasedEvent += OnGemCountChanged;
            UpdateUI(0);
        }

        private void OnDestroy()
        {
            CurrencyManager.CurrencyIncreasedEvent -= OnGemCountChanged;
        }

        private void OnGemCountChanged(long amount)
        {
            UpdateUI(amount);
        }

        private void UpdateUI(long amount)
        {
            m_Sum = Math.Clamp(m_Sum + amount, 0, m_ScoreThreshold);
            if (m_Sum ==  m_ScoreThreshold)
            {
                // TODO: Move this to AbilityManager
                ScoreBarCompletedEvent?.Invoke();
                m_Sum = 0;
            }
            
            float fillPercentage = (m_Sum) / (float)m_ScoreThreshold;
            
            _barTweener?.Complete();
            _barTweener = transform.DOShakeScale(0.3f, new Vector3(0.1f, 0.1f, 0.1f)).SetLink(gameObject).SetLink(gameObject);
            if (m_FillImage)
                m_FillImage.DOFillAmount(fillPercentage, 0.5f).SetEase(Ease.InOutSine).SetLink(gameObject);
        }
    }
}
