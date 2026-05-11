using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    [SerializeField] private float m_CollectDistance = 0.4f;
    [SerializeField] private float m_CollectSpeed;
    [SerializeField] private LayerMask m_GemLayer;
    
    [SerializeField] private PlayerData m_PlayerData;
    
    private List<Gem> _nearbyGems;
    
    private long _gemCount;
    private readonly string _gemCountKey = "GemCount";

    private void Awake()
    {
        SetGemCount(SaveManager.LoadLong(_gemCountKey, 0));
    }
    
    private void Start()
    {
        _nearbyGems = new List<Gem>();
        m_PlayerData.m_GemCount.SetValue(_gemCount);
        
        m_PlayerData.m_GemCount.ValueChangedEvent += OnGemCountChanged;
    }

    private void OnGemCountChanged()
    {
        print(_gemCount);
        _gemCount = m_PlayerData.GetGemCount();
        print(_gemCount);
    }

    private void FixedUpdate()
    {
        Attract();
    }

    private void OnTriggerEnter(Collider other)
    {
        Gem gem = other.gameObject.GetComponentInParent<Gem>();
        if (_nearbyGems.Contains(gem)) return;
        _nearbyGems.Add(gem);
    }
    
    private void Attract()
    {
        if (_nearbyGems.Count <= 0) return;
        for (int i = _nearbyGems.Count - 1; i >= 0; i--)
        {
            Gem gem = _nearbyGems[i];
            if (!gem)
            {
                _nearbyGems.RemoveAt(i);
                continue;
            }
            gem.AttractTo(transform);
            if (Vector3.Distance(transform.position, gem.transform.position) <= m_CollectDistance)
            {
                _gemCount += gem.GemValue;
                SetGemCount(_gemCount);
                SaveManager.SaveLong(_gemCountKey, _gemCount);
                _nearbyGems.RemoveAt(i);
                Destroy(gem.gameObject);
            }
        }
    }

    public void SetGemCount(long gemCount)
    {
        m_PlayerData.m_GemCount.SetValue(gemCount);
        _gemCount = gemCount; 
    }
    
    public void ReduceGemCount(int amount)
    {
        _gemCount -= amount;
        m_PlayerData.m_GemCount.SetValue(_gemCount);
    }
}
