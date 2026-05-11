using DG.Tweening;
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

        private void Start()
        {
            CurrencyManager.CurrencyChangedEvent += OnGemCountChanged;
            UpdateUI();
        }

        private void OnDestroy()
        {
            CurrencyManager.CurrencyChangedEvent -= OnGemCountChanged;
        }

        private void OnGemCountChanged()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            long gemCount = 200;
            float fillPercentage = (CurrencyManager.Instance.GetCurrentGemCount() % m_ScoreThreshold) / (float)m_ScoreThreshold;
            
            _barTweener?.Complete();
            _barTweener = transform.DOShakeScale(0.3f, new Vector3(0.1f, 0.1f, 0.1f)).SetLink(gameObject).SetLink(gameObject);
            if (m_FillImage)
                m_FillImage.DOFillAmount(fillPercentage, 0.5f).SetEase(Ease.InOutSine).SetLink(gameObject);
        }
    }
}
