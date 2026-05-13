using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ShooterGame.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Upgrade Data")]
    public class UpgradeData : ScriptableObject
    {
        public event Action UpgradeCompleteEvent;
        
        [Header("Current Values")]
        [HideInInspector] public string m_UpgradeName;
        [HideInInspector] public int m_Damage;
        [HideInInspector] public long m_Cost;
        [HideInInspector] public int m_Level;

        [Header("Default Values")]
        [SerializeField] private int m_DefaultDamage;
        [SerializeField] private int m_DefaultCost;
        [SerializeField] private int m_CostMultiplier;
        [SerializeField] private int m_DamageIncrement;

        public int DefaultDamage => m_DefaultDamage;
        public int DefaultCost => m_DefaultCost;
        
        [Button]
        public void ResetData()
        {
            m_Cost = m_DefaultCost;
            m_Damage = m_DefaultDamage;
            m_Level = 1;
        }

        public void UpdateData()
        {
            UpgradeCompleteEvent?.Invoke();
        }
        
        public void CompleteUpgrade()
        {
            m_Level++;
            m_Cost *= m_CostMultiplier;
            m_Damage += m_DamageIncrement;
            UpgradeCompleteEvent?.Invoke();
        }
    }
}