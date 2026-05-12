using ShooterGame.Data;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeData m_UpgradeData;

    private void Start()
    {
        //m_UpgradeData.UpgradeCompleteEvent += OnUpgradeCompleteEvent;
    }

    private void OnUpgradeCompleteEvent()
    {
    }

    private void SaveUpgradeData()
    {
        
    }

    public UpgradeData GetUpgradeData()
    {
        return m_UpgradeData;
    }
}
