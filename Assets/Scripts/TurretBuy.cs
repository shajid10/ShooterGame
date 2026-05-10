using UnityEngine;

public class TurretBuy : MonoBehaviour
{
    [SerializeField] private int m_TurretPrice;
    [SerializeField] private TMPro.TextMeshProUGUI m_CostText;
    [SerializeField] private Turret m_TurretPrefab;
    
    private GemSpawnerPlayer _gemSpawnerPlayer;
    
    private string _objectName;
    private string _saveKey;

    private void Awake()
    {
        _objectName = gameObject.name;
        _saveKey = $"TurretPrice_{_objectName}";
        
        if (SaveManager.HasKey(_saveKey))
        {
            if (SaveManager.LoadInt(_saveKey, 0) <= 0)
            {
                CompletePurchase();
                return;
            }
        }
        else
        {
            SavePrice();
        }
        
        LoadPrice();
        UpdateUI();
    }
    
    
    private void Start()
    {
        
        _gemSpawnerPlayer = Player.Instance.GetComponentInChildren<GemSpawnerPlayer>();
        _gemSpawnerPlayer.GemDumpedEvent += OnGemSpawnerGemDumped;
        
        UpdateUI();
    }

    private void OnGemSpawnerGemDumped(TurretBuy obj)
    {
        if (this == obj)
        {
            m_TurretPrice -= 100;
            SavePrice();
            if (m_TurretPrice <= 0)
            {
                CompletePurchase();
            }
            UpdateUI();
        }
    }

    private void SavePrice()
    {
        SaveManager.SaveInt(_saveKey, m_TurretPrice);
    }

    private void LoadPrice()
    {
        m_TurretPrice = SaveManager.LoadInt(_saveKey, m_TurretPrice);
        
    }

    private void CompletePurchase()
    {
        Instantiate(m_TurretPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void UpdateUI()
    {
        m_CostText.text = m_TurretPrice.ToString();
    }
}
