using DG.Tweening;
using UnityEngine;

public class GemSpawnerPlayer : MonoBehaviour
{
    [SerializeField] private GameObject m_GemPrefab;
    [SerializeField] private float m_DetectionRadius;
    [SerializeField] private float m_SpawnDelay;
    private TurretBuy _nearestBuyLocation;
    private GemCollector _gemCollector;
    private float _timeElapsed = 0f;

    private void Start()
    {
        _gemCollector = Player.Instance.GetGemCollector();
    }
    
    // private void FindNearestBuyLocation()
    // {
    //     Collider[] hit = Physics.OverlapSphere(transform.position, m_DetectionRadius);
    //     if (hit.Length > 0 && hit[0].gameObject.CompareTag($"BuyLocation"))
    //     {
    //         _nearestBuyLocation = hit[0].transform;
    //     }
    //     else
    //     {
    //         _nearestBuyLocation = null;
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"BuyLocation"))
        {
            _nearestBuyLocation = other.gameObject.GetComponent<TurretBuy>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag($"BuyLocation"))
        {
            _nearestBuyLocation = other.gameObject.GetComponent<TurretBuy>();
        }
    }

    private void SpawnGem()
    {
        print("gem spawned");
        _gemCollector.ReduceGemCount(100);
        GameObject gem = Instantiate(m_GemPrefab, transform.position, transform.rotation);
        
        gem.transform.DOJump(_nearestBuyLocation.transform.position, 3f, 1, 1f)
            .SetEase(Ease.InQuad)
            .SetLink(gameObject)
            .OnComplete(() =>
            {
                if (_nearestBuyLocation)
                {;
                    _nearestBuyLocation.GetGem();
                }
                
                Destroy(gem);
            });
    }

    private void FixedUpdate()
    {  
        _timeElapsed += Time.deltaTime;
        if ( _nearestBuyLocation && _timeElapsed >= m_SpawnDelay && _gemCollector.GetGemCount() >= 100)
        {
            SpawnGem();
            _timeElapsed = 0f;
        }
    }
}
