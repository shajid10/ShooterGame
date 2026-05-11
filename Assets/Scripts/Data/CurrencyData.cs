using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "ScriptableObjects/CurrencyData")]
    public class CurrencyData : ScriptableObject
    {
        public long m_CurrentGemCount;
    }
}
