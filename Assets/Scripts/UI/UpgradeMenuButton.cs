using ShooterGame.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeMenuButton : MonoBehaviour
    {
        [SerializeField] UpgradePanel m_UpgradePanel;
        private Button _button;
        
        private void Start()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            m_UpgradePanel.ToggleUpgradePanel();
        }
    }
}
