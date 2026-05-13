using ShooterGame.Player;
using ShooterGame.Spawners;
using ShooterGame.Weapons;
using UnityEngine;

public class TurretBuy : MonoBehaviour
{
    [SerializeField] private int m_TurretPrice;
    [SerializeField] private TMPro.TextMeshProUGUI m_CostText;
    [SerializeField] private Turret m_TurretPrefab;
    
    private GemSpawnerPlayer _gemSpawnerPlayer;

    private int _pendingGemValue = 0;
    
    private string _objectName;
    private string _saveKey;
    // add serialized field for save key
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

    private void OnDestroy()
    {
        if (_gemSpawnerPlayer)
            _gemSpawnerPlayer.GemDumpedEvent -= OnGemSpawnerGemDumped;
    }

    private void OnGemSpawnerGemDumped(TurretBuy obj)
    {
        if (this == obj)
        {
            int gemValue = CurrencyManager.Instance.GetGemValue();
            m_TurretPrice -= gemValue;
            _pendingGemValue -= gemValue;
            
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

    public void ExpectGem(int value)
    {
        _pendingGemValue += value;
    }
    
    public bool CanReceiveGem()
    {
        return (m_TurretPrice - _pendingGemValue) > 0;
    }
}
