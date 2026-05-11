using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeMenuButton : MonoBehaviour
    {
        [SerializeField] private UpgradePanel m_upgradePanel;
        
        private Button _button;
        
        private void Start()
        {
             _button = GetComponent<Button>();
             _button.onClick.AddListener(OpenUpgradeMenu);
        }

        private void OpenUpgradeMenu()
        {
            m_upgradePanel.ToggleUpgradePanel();
        }
    }
}
