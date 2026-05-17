using ShooterGame.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private Button m_AddCurrencyButton;
    [SerializeField] private Button m_ResetCurrencyButton;
    [SerializeField] private Button m_ResetUpgradesButton;
    [SerializeField] private Button m_ClearPlayerPrefsButton;
    
    [SerializeField] private UpgradeData m_PlayerUpgradeData;
    [SerializeField] private UpgradeData m_TurretUpgradeData;

    private void Start()
    {
        m_AddCurrencyButton.onClick.AddListener(AddCurrency);
        m_ResetCurrencyButton.onClick.AddListener(ResetCurrency);
        m_ResetUpgradesButton.onClick.AddListener(ResetUpgrades);
        m_ClearPlayerPrefsButton.onClick.AddListener(ClearPlayerPrefs);
    }

    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void AddCurrency()
    {
        CurrencyManager.Instance.IncrementGemCount(500);
    }

    private void ResetCurrency()
    {
        CurrencyManager.Instance.ResetGemCount();
    }

    private void ResetUpgrades()
    {
        m_PlayerUpgradeData.ResetData();
        m_TurretUpgradeData.ResetData();
    }
}
