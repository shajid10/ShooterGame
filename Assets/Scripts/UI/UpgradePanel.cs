using System;

namespace UI
{
    public class UpgradePanel : TSF.UI.UIPanelBase
    {
        private void Start()
        { 
            Hide();
        }

        public void ToggleUpgradePanel()
        {
            if (m_Canvas.gameObject.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }
}
