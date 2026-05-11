using ScriptableObjects.VariableSO;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjects/TurretSO", menuName = "TurretSO")]
    public class TurretSO : ScriptableObject
    {
        public IntVariableSO m_Level;
        public LongVariableSO m_UpgradePrice;
        public IntVariableSO m_Damage;
    }
}
