using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretBuy : MonoBehaviour
{
    [SerializeField] private Image m_FillImage;
    [SerializeField] private int m_TurretCost;
    [SerializeField] private float m_FillDuration;
    [SerializeField] private Transform m_TurretSpawnPoint;
    [SerializeField] private GameObject m_TurretPrefab;

    private TMP_Text _costText;
    private int _remainingCost;
    private int _gemValue = 100;

    private GemCollector _gemCollector;
    private Tween _fillTween;

    private void Start()
    {
        _gemCollector = Player.Instance.GetComponent<GemCollector>();
        _remainingCost = m_TurretCost;
        _costText = GetComponentInChildren<TMP_Text>();
    }

    private void OnPurchaseCompleted()
    {
        // spawn turret
        Instantiate(m_TurretPrefab, m_TurretSpawnPoint.position, m_TurretSpawnPoint.rotation);
        Destroy(gameObject);
    }

    public void GetGem()
    {
        if (_remainingCost != 0)
        {
            _remainingCost -= _gemValue;
            _costText.text = $"{_remainingCost}";
        }
        else
        {
            OnPurchaseCompleted();
        }
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         if (_gemCollector.GetGemCount() >= m_TurretCost)
    //             StartFilling();
    //         if (_gemCollector.GetGemCount() < m_TurretCost)
    //             StopFilling();
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         StopFilling();
    //     }
    // }

    // private void StartFilling()
    // {
    //     _fillTween?.Kill();
    //     
    //     _fillTween = m_FillImage.DOFillAmount(1f, m_FillDuration)
    //         .SetEase(Ease.Linear)
    //         .SetLink(gameObject)
    //         .OnComplete(OnPurchaseCompleted);
    // }
    //
    // private void StopFilling()
    // {
    //     _fillTween.Kill();
    //     m_FillImage.fillAmount = 0f;
    // }
}
