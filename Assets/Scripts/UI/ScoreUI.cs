using DG.Tweening;
using ScriptableObjects;
using TMPro;
using TSF.Utilities;
using UnityEngine;

namespace ShooterGame.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Text;
        
        [SerializeField] private PlayerData m_PlayerData;
        
        private Tweener _textTweener;
        private CurrencyManager _currencyManager;

        private void Start()
        {
            //m_PlayerData.m_GemCount.ValueChangedEvent += OnGemCountChanged;
            _currencyManager = CurrencyManager.Instance;
            CurrencyManager.CurrencyChangedEvent += OnGemCountChanged;
            
            m_Text.text = "0";
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
            m_Text.text = Helper.GetRoundUpNumbersAsString(_currencyManager.GetCurrentGemCount());
            
            _textTweener?.Complete();
            _textTweener = m_Text.transform.DOPunchScale(Vector3.one * 0.5f, 0.2f).SetLink(gameObject);
        }
    }
}
