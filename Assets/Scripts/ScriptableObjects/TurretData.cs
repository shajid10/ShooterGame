using ScriptableObjects.VariableSO;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjects/TurretSO", menuName = "TurretSO")]
    public class TurretData : ScriptableObject
    {
        public int m_Level;
        public long m_UpgradePrice;
        public int m_Damage;
        
        public void ResetValues()
        {
            m_Level.Initialize();
            m_UpgradePrice.Initialize();
            m_Damage.Initialize();
        }
    }
}
