using System;
using Data;
using Sirenix.OdinInspector;
using UnityEngine;


public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    public static event Action CurrencyChangedEvent;
    
    [SerializeField] private CurrencyData m_CurrencyData;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public long GetCurrentGemCount()
    {
        return m_CurrencyData.m_CurrentGemCount;
    }

    [Button]
    public void SetCurrentGemCount(long gemCount)
    {
        m_CurrencyData.m_CurrentGemCount = gemCount;
        CurrencyChangedEvent?.Invoke();
    }

    public void IncrementGemCount(long gemCount)
    {
        m_CurrencyData.m_CurrentGemCount += gemCount;
        CurrencyChangedEvent?.Invoke();
    }
    
    public void DecrementGemCount(long gemCount)
    {
        m_CurrencyData.m_CurrentGemCount -= gemCount;
        CurrencyChangedEvent?.Invoke();
    }
}
