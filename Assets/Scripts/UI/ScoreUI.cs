using TMPro;
using UnityEngine;
using TSF.Utilities;
using DG.Tweening;
using ScriptableObjects;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Text;
        
        [SerializeField] private PlayerData m_PlayerData;
        
        private GemCollector _gemCollector;
        //private Player _player;
        

        private Tweener _textTweener;

        private void Start()
        {
            m_PlayerData.m_GemCount.ValueChangedEvent += OnGemCountChanged;
            m_Text.text = "0";
            UpdateUI();
        }

        private void OnDestroy()
        {
            m_PlayerData.m_GemCount.ValueChangedEvent -= OnGemCountChanged;
        }

        private void OnGemCountChanged()
        {
            print("gem count changed");
            UpdateUI();
        }

        private void UpdateUI()
        {
            long gemCount = m_PlayerData.m_GemCount.Value;
            m_Text.text = Helper.GetRoundUpNumbersAsString(gemCount);
            
            _textTweener?.Complete();
            _textTweener = m_Text.transform.DOPunchScale(Vector3.one * 0.5f, 0.2f).SetLink(gameObject);
        }
    }
}
