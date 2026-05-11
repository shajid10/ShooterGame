using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerSO")]
    public class PlayerData : ScriptableObject
    {
        public int m_Level;
        public int m_Damage;
        public long m_UpgradePrice;
        
        // make this global currency
        //public LongVariableSO m_GemCount;

        [Button]
        public void ResetValues()
        {
            m_Level = 1;
            m_Damage = 20;
            m_UpgradePrice = 200;
        }

    }
}
