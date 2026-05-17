using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "ScriptableObjects/CurrencyData")]
    public class CurrencyData : ScriptableObject
    {
        public long m_CurrentGemCount;
        public long m_CurrentScore;
        public long m_CurrentTokenCount;

        public long m_ScoreValue;
    }
}
