using UnityEngine;

public class GemCollector : MonoBehaviour
{
    [SerializeField] private float m_CollectRadius = 5f;
    [SerializeField] private float m_CollectDistance = 0.4f;
    [SerializeField] private float m_CollectSpeed;
    [SerializeField] private LayerMask m_GemLayer;
    
    private Collider[] _hits;
    
    private int _gemCount = 0;
    
    private void Start() {}

    private void FixedUpdate()
    {
        _hits = Physics.OverlapSphere(transform.position, m_CollectRadius, m_GemLayer);
        Attract();
    }

    private void Attract()
    {
        foreach (Collider hit in _hits)
        {
            Gem gem = hit.gameObject.GetComponentInParent<Gem>();
            if (gem)
            {
                print("gem found");
                gem.AttractTo(transform);
                if (Vector3.Distance(transform.position, gem.transform.position) <= m_CollectDistance)
                {
                    _gemCount++;
                    Destroy(gem.gameObject);
                }
            }
        }
    }
}
