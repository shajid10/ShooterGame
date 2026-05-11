using UnityEngine;

namespace ShooterGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjects/TurretSO", menuName = "TurretSO")]
    public class TurretData : ScriptableObject
    {
        public int m_Level;
        public long m_UpgradePrice;
        public int m_Damage;
        
        public void ResetValues()
        {
            m_Level = 1;
            m_UpgradePrice = 200;
            m_Damage = 30;
        }
    }
}
