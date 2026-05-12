
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame.UI
{
    public class UpgradePanel : TSF.UI.UIPanelBase
    {
        [SerializeField] private Button m_CloseButton;
        [SerializeField] private float m_SlideDuration;
        [SerializeField] private RectTransform m_UpgradePanelRect;

        private bool _panelVisible;
        
        private void Start()
        {
            m_CloseButton.onClick.AddListener(OnCloseButtonClicked);
            Hide();
        }

        private void OnCloseButtonClicked()
        {
            if (_panelVisible)
            {
                Hide();
                _panelVisible = false;
            }
        }

        public void ToggleUpgradePanel()
        {
            if (_panelVisible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        [Button]
        protected override void Show()
        {
            //m_Canvas.gameObject.SetActive(true);
            //m_Panel.alpha = 0;
            InputController.Instance.DisableJoystick();
            m_UpgradePanelRect.DOAnchorPosY(20, m_SlideDuration).SetEase(Ease.OutBack, 1f);
            _panelVisible = true;
        }

        [Button]
        protected override void Hide()
        {
            InputController.Instance.EnableJoystick();
            m_UpgradePanelRect.DOAnchorPosY(2500, m_SlideDuration).SetEase(Ease.OutCubic);
            _panelVisible = false;
        }
    }
}
