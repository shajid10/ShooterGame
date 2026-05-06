using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TurretBuy : MonoBehaviour
{
    [SerializeField] private Image m_FillImage;
    [SerializeField] private int m_TurretCost;
    [SerializeField] private float m_FillDuration;

    private GemCollector _gemCollector;
    private Tween _fillTween;

    private void Start()
    {
        _gemCollector = Player.Instance.GetComponent<GemCollector>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_gemCollector.GetGemCount() >= m_TurretCost)
                StartFilling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_gemCollector.GetGemCount() < m_TurretCost)
                StopFilling();
        }
    }

    private void StartFilling()
    {
        _fillTween?.Kill();
        
        _fillTween = m_FillImage.DOFillAmount(1f, m_FillDuration)
            .SetEase(Ease.Linear)
            .SetLink(gameObject)
            .OnComplete(OnPurchaseCompleted);
    }

    private void StopFilling()
    {
        _fillTween?.Kill();
        m_FillImage.fillAmount = 0f;
    }

    private void OnPurchaseCompleted()
    {
        _gemCollector.ReduceGemCount(m_TurretCost);
        // spawn turret
        Destroy(gameObject);
    }
}
