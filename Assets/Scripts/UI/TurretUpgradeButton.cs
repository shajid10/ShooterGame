using ScriptableObjects;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TurretUpgradeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_LevelText;
    [SerializeField] private TextMeshProUGUI m_DamageText;
    [SerializeField] private TextMeshProUGUI m_CostText;

    [SerializeField] private TurretData m_TurretData;
    [SerializeField] private PlayerData m_PlayerData;

    [SerializeField] private Button m_BuyButton;

    private bool interactability = false;

    private void Start()
    {
        m_TurretData.m_Damage.ValueChangedEvent += OnTurretDamageValueChanged;
        m_TurretData.m_UpgradePrice.ValueChangedEvent += OnUpgradePriceValueChanged;
        m_TurretData.m_Level.ValueChangedEvent += OnTurretLevelChanged;
        
        m_PlayerData.m_GemCount.ValueChangedEvent += OnGemCountChanged;

        m_BuyButton.onClick.AddListener(OnUpgradeButtonClicked);

        m_TurretData.ResetValues();
        UpdateUI();
    }

    private void OnDisable()
    {
        m_TurretData.m_Damage.ValueChangedEvent -= OnTurretDamageValueChanged;
        m_TurretData.m_UpgradePrice.ValueChangedEvent -= OnUpgradePriceValueChanged;
        m_TurretData.m_Level.ValueChangedEvent -= OnTurretLevelChanged;
        
        m_PlayerData.m_GemCount.ValueChangedEvent -= OnGemCountChanged;
    }

    private void OnGemCountChanged()
    {
        if (m_PlayerData.GetGemCount() >= m_TurretData.m_UpgradePrice.Value)
        {
            //m_BuyButton.interactable = true;
            interactability = true;
        }
        else
        {
            //m_BuyButton.interactable = false;
            interactability = false;
        }
        
        UpdateUI();
    }

    private void OnUpgradeButtonClicked()
    {

        // long gems = m_PlayerData.GetGemCount();
        // if (m_PlayerData.GetGemCount() >= m_TurretData.m_UpgradePrice.Value)
        //     m_PlayerData.m_GemCount.SetValue(gems - m_TurretData.m_UpgradePrice.Value);
        // else return;
        //
        // m_TurretData.m_Level.SetValue(m_TurretData.m_Level.Value + 1);
        // m_TurretData.m_Damage.SetValue(m_TurretData.m_Damage.Value + 10);
        // m_TurretData.m_UpgradePrice.SetValue(m_TurretData.m_UpgradePrice.Value + 200);
        //
        // UpdateUI();
    }

    private void OnUpgradePriceValueChanged()
    {
        // m_CostText.text = m_TurretData.m_UpgradePrice.Value.ToString() + "$";
    }

    private void OnTurretDamageValueChanged()
    {
        // m_DamageText.text = m_TurretData.m_Damage.Value.ToString();
    }

    private void OnTurretLevelChanged()
    {
        // m_LevelText.text = "Level " + m_TurretData.m_Level.Value.ToString();
    }


    private void UpdateUI()
    {
        // m_LevelText.text = "Level " + m_TurretData.m_Level.Value.ToString();
        // m_DamageText.text = m_TurretData.m_Damage.Value.ToString();
        // m_CostText.text = m_TurretData.m_UpgradePrice.Value.ToString() + "$";
        // m_BuyButton.interactable = interactability;
    }
}