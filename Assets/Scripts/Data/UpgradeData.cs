using System;
using UnityEngine;

namespace ShooterGame.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Upgrade Data")]
    public class UpgradeData : ScriptableObject
    {
        public event Action UpgradeCompleteEvent;
        
        public string m_UpgradeName;
        public int m_Damage;
        public long m_Cost;
        public int m_Level;
        
        [SerializeField] private int m_CostMultiplier;
        [SerializeField] private int m_DamageIncrement;
        
        
        public void CompleteUpgrade()
        {
            m_Level++;
            m_Cost *= m_CostMultiplier;
            m_Damage += m_DamageIncrement;
            UpgradeCompleteEvent?.Invoke();
        }
    }
}