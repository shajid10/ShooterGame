using UnityEngine;

public class HitBoxComponent : MonoBehaviour
{
    [SerializeField] private int m_Damage;

    public int Damage
    {
        get => m_Damage;
        private set => m_Damage = value;
    }
}
