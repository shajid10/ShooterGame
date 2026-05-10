using TMPro;
using UnityEngine;
using TSF.Utilities;
using DG.Tweening;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Text;
        
        private GemCollector _gemCollector;
        private Player _player;

        private Tweener _textTweener;

        private void Start()
        {
            _player = Player.Instance;
            _gemCollector = _player.GetGemCollector();
            
            _gemCollector.GemCountChangedEvent += OnGemCountChanged;
            m_Text.text = "0";
            UpdateUI();
        }

        private void OnDestroy()
        {
            _gemCollector.GemCountChangedEvent -= OnGemCountChanged;
        }

        private void OnGemCountChanged()
        {
            print("gem counnt changed");
            UpdateUI();
        }

        private void UpdateUI()
        {
            long gemCount = _gemCollector.GetGemCount();
            m_Text.text = Helper.GetRoundUpNumbersAsString(gemCount);
            
            _textTweener?.Complete();
            _textTweener = m_Text.transform.DOPunchScale(Vector3.one * 0.5f, 0.2f).SetLink(gameObject);
        }
    }
}
