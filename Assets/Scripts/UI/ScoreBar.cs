using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private Image m_FillImage;
        [SerializeField] private int m_ScoreThreshold;
        
        [SerializeField] private PlayerSO m_Player;
        private GemCollector _gemCollector;

        private Tweener _barTweener;

        private void Start()
        {
            m_Player.m_GemCount.ValueChangedEvent += OnGemCountChanged;
            UpdateUI();
        }

        private void OnDestroy()
        {
            m_Player.m_GemCount.ValueChangedEvent -= OnGemCountChanged;
        }

        private void OnGemCountChanged()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            long gemCount = m_Player.m_GemCount.Value;
            float fillPercentage = (gemCount%m_ScoreThreshold) / (float)m_ScoreThreshold;
            
            _barTweener?.Complete();
            _barTweener = transform.DOShakeScale(0.3f, new Vector3(0.1f, 0.1f, 0.1f)).SetLink(gameObject).SetLink(gameObject);
            if (m_FillImage)
                m_FillImage.DOFillAmount(fillPercentage, 0.5f).SetEase(Ease.InOutSine).SetLink(gameObject);
        }
    }
}
