using UnityEngine;

public class LootDropManager : MonoBehaviour
{
    [SerializeField] private HealthPickup m_LootDropPrefab;

    public void SpawnLootDropBasedOnChance(float chance)
    {
        if (Random.Range(0f, 1f) <= chance) 
            Instantiate(m_LootDropPrefab, transform.position, Quaternion.identity);
    }
}
