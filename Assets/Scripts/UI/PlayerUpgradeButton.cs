using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame.UI
{
    public class PlayerUpgradeButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_LevelText;
        [SerializeField] private TextMeshProUGUI m_DamageText;
        [SerializeField] private TextMeshProUGUI m_CostText;
        
        [SerializeField] private PlayerData m_PlayerData;
        
        [SerializeField] private Button m_BuyButton;

        private void Start()
        {
            
            m_BuyButton.onClick.AddListener(OnUpgradeButtonClicked);
            
            m_PlayerData.ResetValues();
            UpdateUI();
        }

        private void OnDisable()
        {
        }

        private void OnGemCountChanged()
        {
        }

        private void OnUpgradeButtonClicked()
        {
            
            UpdateUI();
        }

        private void OnUpgradePriceValueChanged()
        {
            m_CostText.text = m_PlayerData.m_UpgradePrice.ToString() + "$";
        }

        private void OnDamageValueChanged()
        {
            m_DamageText.text = m_PlayerData.m_Damage.ToString();
        }

        private void OnLevelChanged()
        {
            m_LevelText.text = "Level " + m_PlayerData.m_Level.ToString();
        }
        

        private void UpdateUI()
        {
            m_LevelText.text = "Level " + m_PlayerData.m_Level.ToString();
            m_DamageText.text = m_PlayerData.m_Damage.ToString();
            m_CostText.text = m_PlayerData.m_UpgradePrice.ToString() + "$";
        }
    }
}
