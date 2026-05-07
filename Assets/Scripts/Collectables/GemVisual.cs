using System;
using UnityEngine;

public class GemVisual : MonoBehaviour
{
    [SerializeField] private GemSO m_GemSo;
    private int _gemValue;

    private void Start()
    {
        _gemValue = m_GemSo.Value;
    }
    
    public int GetGemValue() => _gemValue;
}
