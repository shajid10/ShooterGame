using UnityEngine;

namespace ShooterGame.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public string m_EnemyName;
        public int m_Damage = 10;
        public float m_Speed = 3;
        public int m_Health = 100;
    }
}
