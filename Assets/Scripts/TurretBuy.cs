using System.Collections;
using ShooterGame.Player;
using ShooterGame.Spawners;
using ShooterGame.Utils;
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
            _pendingGemValue -= gemValue;
            
            m_TurretPrice -= gemValue;
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
        
        
        if (_pendingGemValue <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            // Start a Coroutine to wait for gems to finish landing then destroy
            StartCoroutine(WaitAndDestroy());
        }
    }

    private void UpdateUI()
    {
        m_CostText.text = Util.GetRoundUpNumbersAsStringGranular(m_TurretPrice);
    }

    public void ExpectGem(int value)
    {
        _pendingGemValue += value;
    }
    
    public bool CanReceiveGem()
    {
        return (m_TurretPrice - _pendingGemValue) > 0;
    }
    
    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitUntil(() => _pendingGemValue <= 0);
        Destroy(gameObject);
    }
}
