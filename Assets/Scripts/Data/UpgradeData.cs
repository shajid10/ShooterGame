using UnityEngine;

namespace ShooterGame.Data
{
    public class UpgradeData : ScriptableObject
    {
        [SerializeField] private string m_Name;
        [SerializeField] private int m_Damage;
        [SerializeField] private long m_Cost;
        [SerializeField] private int m_Level;
    }
}