using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame.UI
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private Image m_FillImage;

        private Tweener _barTweener;

        private void Start()
        {
            AbilityManager.ProgressChangedEvent += OnProgressChanged;
            //UpdateUI(0);
        }

        private void OnDestroy()
        {
            AbilityManager.ProgressChangedEvent -= OnProgressChanged;
        }

        private void OnProgressChanged(float fillPercentage)
        {
            print("progress changed:  " + fillPercentage);
            _barTweener?.Complete();
            _barTweener = transform.DOShakeScale(0.3f, new Vector3(0.1f, 0.1f, 0.1f)).SetLink(gameObject);
            
            if (m_FillImage)
            {
                m_FillImage.DOFillAmount(fillPercentage, 0.5f)
                    .SetEase(Ease.InOutSine)
                    .SetLink(gameObject);
            }
        }
    }
}
