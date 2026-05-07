using UnityEngine;

public class TurretBuy : MonoBehaviour
{
    [SerializeField] private int m_TurretPrice;
    [SerializeField] private TMPro.TextMeshProUGUI m_CostText;
    [SerializeField] private Turret m_TurretPrefab;
    
    private GemSpawnerPlayer _gemSpawnerPlayer;
    
    private void Start()
    {
        _gemSpawnerPlayer = Player.Instance.GetComponentInChildren<GemSpawnerPlayer>();
        _gemSpawnerPlayer.GemDumpedEvent += OnGemSpawnerGemDumped;
        
        m_CostText.text = m_TurretPrice.ToString();
    }

    private void OnGemSpawnerGemDumped(TurretBuy obj)
    {
        if (this == obj)
        {
            m_TurretPrice -= 100;
            if (m_TurretPrice <= 0)
            {
                Instantiate(m_TurretPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            m_CostText.text = m_TurretPrice.ToString();
        }
    }
}
