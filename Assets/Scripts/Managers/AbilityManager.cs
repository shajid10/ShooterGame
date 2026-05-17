using System;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private float m_ThresholdMultiplier = 2;
    private long _scoreThreshold = 500;
    private long _currentScore = 0;
    

    public static event Action<float> ProgressChangedEvent;

    private void Start()
    {
        CurrencyManager.ScoreIncreasedEvent += OnScoreIncreased;
        _currentScore = CurrencyManager.Instance.GetScore();
    }

    private void OnDestroy()
    {
        CurrencyManager.ScoreIncreasedEvent -= OnScoreIncreased;
    }

    private void OnScoreIncreased()
    {
        _currentScore = CurrencyManager.Instance.GetScore();
        if (_currentScore >= _scoreThreshold)
        {
            _currentScore = 0;
            _scoreThreshold = (long)((float)_scoreThreshold * m_ThresholdMultiplier);
            TriggerAbilityUnlock();
        }
        
        float fillPercent = (float)_currentScore / _scoreThreshold;
        CurrencyManager.Instance.SetScore(_currentScore);
        ProgressChangedEvent?.Invoke(fillPercent);
    }

    private void TriggerAbilityUnlock()
    {
        // trigger ability unlock
        print("ability unlock");
    }
}
