using ShooterGame.Data;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeData m_UpgradeData;

    private void Start()
    {
        m_UpgradeData.UpgradeCompleteEvent += OnUpgradeCompleteEvent;
        
        m_UpgradeData = SaveManager.LoadUpgradeData(m_UpgradeData);
    }

    private void OnUpgradeCompleteEvent()
    {
        SaveManager.SaveUpgradeData(m_UpgradeData);
    }

    public UpgradeData GetUpgradeData()
    {
        return m_UpgradeData;
    }
}
