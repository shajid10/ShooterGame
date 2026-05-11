using ScriptableObjects.VariableSO;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerSO")]
    public class PlayerSO : ScriptableObject
    {
        public int m_MaxPlayerHealth;
        public IntVariableSO m_PlayerLevel;
        public IntVariableSO m_PlayerDamage;
        public LongVariableSO m_NextLevelPrice;
        public LongVariableSO m_GemCount;
    }
}
