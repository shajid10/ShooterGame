using System;
using UnityEngine;
using TSF.Utilities;
using UnityEditor;

public class GemCollector : MonoBehaviour
{
    [SerializeField] private float m_CollectRadius = 5f;
    [SerializeField] private float m_CollectDistance = 0.4f;
    [SerializeField] private float m_CollectSpeed;
    [SerializeField] private LayerMask m_GemLayer;
    
    private Collider[] _hits;
    
    private long _gemCount = 0;
    
    public event EventHandler OnGemCountChanged;
    
    private void Start() {}

    
    //to do: Replace with ontrigger enter events
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
                gem.AttractTo(transform);
                if (Vector3.Distance(transform.position, gem.transform.position) <= m_CollectDistance)
                {
                    _gemCount += 100;
                    OnGemCountChanged?.Invoke(this, EventArgs.Empty);
                    Destroy(gem.gameObject);
                }
            }
        }
    }
    
    public long  GetGemCount() {return _gemCount;}

    public void ReduceGemCount(int amount)
    {
        _gemCount -= amount;
        OnGemCountChanged?.Invoke(this, EventArgs.Empty);
    }
}
