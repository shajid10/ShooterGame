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

        private Tweener _barTweener;

        //change event and params
        private void Start()
        {
            _gemCollector = Player.Instance.GetGemCollector();
            _gemCollector.GemCountChangedEvent += OnGemCountChanged;
        }

        private void OnDestroy()
        {
            _gemCollector.GemCountChangedEvent -= OnGemCountChanged;
        }

        private void OnGemCountChanged()
        {
            long gemCount = _gemCollector.GetGemCount();
            float fillPercentage = (gemCount%m_ScoreThreshold) / (float)m_ScoreThreshold;
            
            _barTweener?.Complete();
            _barTweener = transform.DOShakeScale(0.3f, new Vector3(0.2f, 0.2f, 0.2f)).SetLink(gameObject).SetLink(gameObject);
            if (m_FillImage)
                m_FillImage.DOFillAmount(fillPercentage, 0.5f).SetEase(Ease.InOutSine).SetLink(gameObject);
        }
    }
}
