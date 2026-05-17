using DG.Tweening;
using ShooterGame.Components;
using TMPro;
using UnityEngine;

namespace ShooterGame.UI
{
    public class NumberPopUp : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_NumberText;
        [SerializeField] private RectTransform m_RectTransform;
        [SerializeField] private CanvasGroup m_CanvasGroup;
        
        
        private void Start()
        {
            NumberPop();
        }

        private void NumberPop()
        {
            m_CanvasGroup.DOFade(0f, 3f).SetLink(gameObject);
            m_RectTransform.DOAnchorPos3DY(m_RectTransform.anchoredPosition.y + 2, 1f).SetLink(gameObject).OnComplete(
                (() =>
                {
                    Destroy(gameObject);
                }));
        }

        public void SetColor(Color color)
        {
            m_NumberText.color = color;
        }

        public void SetText(string text)
        {
            m_NumberText.text = text;
        }
    }
}
