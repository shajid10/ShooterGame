using System;
using Data;
using ShooterGame.Data;
using Sirenix.OdinInspector;
using UnityEngine;


public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    public static event Action CurrencyChangedEvent;
    public static event Action<long> CurrencyIncreasedEvent;
    
    [SerializeField] private CurrencyData m_CurrencyData;
    [SerializeField] private GemData m_GemData;

    private const string CurrencyKey = "Currency";
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        long loadedCurrency = SaveManager.LoadLong(CurrencyKey, 0);
        SetCurrentGemCount(loadedCurrency);
    }

    public long GetCurrentGemCount()
    {
        return m_CurrencyData.m_CurrentGemCount;
    }

    [Button]
    public void SetCurrentGemCount(long gemCount)
    {
        m_CurrencyData.m_CurrentGemCount = gemCount;
        SaveDataAndInvoke();
    }

    public void IncrementGemCount(long amount)
    {
        m_CurrencyData.m_CurrentGemCount += amount;
        SaveDataAndInvoke();
        CurrencyIncreasedEvent?.Invoke(amount);
    }
    
    public void DecrementGemCount(long amount)
    {
        m_CurrencyData.m_CurrentGemCount -= amount;
        SaveDataAndInvoke();
    }

    public int GetGemValue()
    {
        return m_GemData.m_Value;
    }

    private void SaveDataAndInvoke()
    {
        SaveManager.SaveLong(CurrencyKey, m_CurrencyData.m_CurrentGemCount);
        CurrencyChangedEvent?.Invoke();
    }
}
