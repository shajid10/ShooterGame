using ShooterGame.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeData m_UpgradeData;
    
    [SerializeField] private TextMeshProUGUI m_NameText;
    [SerializeField] private Button m_BuyButton;
    [SerializeField] private TextMeshProUGUI m_CostText;
    [SerializeField] private TextMeshProUGUI m_DamageText;
    [SerializeField] private TextMeshProUGUI m_LevelText;
    
    
    
    private CurrencyManager _currencyManager;

    private void Start()
    {
        _currencyManager = CurrencyManager.Instance;
        
        m_BuyButton.onClick.AddListener(OnBuyButtonClicked);
        
        CurrencyManager.CurrencyChangedEvent += UpdateUI;
        m_UpgradeData.UpgradeCompleteEvent += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        CurrencyManager.CurrencyChangedEvent -= UpdateUI;
    }

    private void OnBuyButtonClicked()
    {
        if (_currencyManager.GetCurrentGemCount() >= m_UpgradeData.m_Cost)
        {
            _currencyManager.DecrementGemCount(m_UpgradeData.m_Cost);
            m_UpgradeData.CompleteUpgrade();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        m_NameText.text = m_UpgradeData.m_UpgradeName;
        m_CostText.text = m_UpgradeData.m_Cost.ToString();
        m_DamageText.text = m_UpgradeData.m_Damage.ToString();
        m_LevelText.text = "Level " + m_UpgradeData.m_Level.ToString();

        if (_currencyManager.GetCurrentGemCount() >= m_UpgradeData.m_Cost)
        {
            m_BuyButton.interactable = true;
        } else  {
            m_BuyButton.interactable = false;
            
        }
    }
}
