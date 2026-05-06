using System;
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

        private void Start()
        {
            _player = Player.Instance;
            //fix
            _gemCollector = _player.GetComponent<GemCollector>();
            
            _gemCollector.OnGemCountChanged += GemCollectorOnOnGemCountChanged;
            m_Text.text = "0";
        }

        private void GemCollectorOnOnGemCountChanged(object sender, EventArgs e)
        {
            long gemCount = _gemCollector.GetGemCount();
            m_Text.text = Helper.GetRoundUpNumbersAsString(gemCount);
            m_Text.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f, 1);
        }
    }
}
