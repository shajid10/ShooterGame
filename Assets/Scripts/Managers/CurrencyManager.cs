using System;
using Data;
using ShooterGame.Data;
using Sirenix.OdinInspector;
using UnityEngine;


public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    public static event Action GemCountChangedEvent;
    public static event Action<long> GemCountIncreasedEvent;
    public static event Action ScoreChangedEvent;
    public static event Action ScoreIncreasedEvent;
    public static event Action TokenCountChangedEvent;
    
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

    
    // Gem count 
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
        GemCountIncreasedEvent?.Invoke(amount);
    }
    
    public void DecrementGemCount(long amount)
    {
        m_CurrencyData.m_CurrentGemCount -= amount;
        SaveDataAndInvoke();
    }
    
    public void ResetGemCount()
    {
        m_CurrencyData.m_CurrentGemCount = 0;
        SaveDataAndInvoke();
    }

    public int GetGemValue()
    {
        return m_GemData.m_Value;
    }
    
    // score
    public long GetScore()
    {
        return m_CurrencyData.m_CurrentScore;
    }

    public void IncrementScore()
    {
        m_CurrencyData.m_CurrentScore += m_CurrencyData.m_ScoreValue;
        ScoreIncreasedEvent?.Invoke();
    }

    public void SetScore(long score)
    {
        m_CurrencyData.m_CurrentScore = score;
        ScoreChangedEvent?.Invoke();
    }
    
    // token
    public long GetCurrentTokenCount()
    {
        return m_CurrencyData.m_CurrentTokenCount;
    }

    public void IncrementTokenCount()
    {
        m_CurrencyData.m_CurrentTokenCount += 1;
        TokenCountChangedEvent?.Invoke();
    }
    
    private void SaveDataAndInvoke()
    {
        SaveManager.SaveLong(CurrencyKey, m_CurrencyData.m_CurrentGemCount);
        GemCountChangedEvent?.Invoke();
    }
}
