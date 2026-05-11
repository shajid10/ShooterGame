using System;
using ScriptableObjects;
using ShooterGame.Data;
using UnityEngine;

public class GemVisual : MonoBehaviour
{
    [SerializeField] private GemData m_GemData;
    private int _gemValue;

    private void Start()
    {
        _gemValue = m_GemData.m_Value;
    }
    
    public int GetGemValue() => _gemValue;
}
