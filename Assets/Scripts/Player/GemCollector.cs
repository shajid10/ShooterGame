using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame.Player
{
    public class GemCollector : MonoBehaviour
    {
        [SerializeField] private float m_CollectDistance = 0.4f;
        [SerializeField] private float m_CollectSpeed;
        [SerializeField] private LayerMask m_GemLayer;
    
        private CurrencyManager _currencyManager;
    
        private List<Gem> _nearbyGems;
    
        private void Start()
        {
            _nearbyGems = new List<Gem>();
        
            _currencyManager = CurrencyManager.Instance;
        }
    

        private void FixedUpdate()
        {
            Attract();
        }

        private void OnTriggerEnter(Collider other)
        {
            Gem gem = other.gameObject.GetComponentInParent<Gem>();
            if (_nearbyGems.Contains(gem)) return;
            _nearbyGems.Add(gem);
        }
    
        private void Attract()
        {
            if (_nearbyGems.Count <= 0) return;
            for (int i = _nearbyGems.Count - 1; i >= 0; i--)
            {
                Gem gem = _nearbyGems[i];
                if (!gem)
                {
                    _nearbyGems.RemoveAt(i);
                    continue;
                }
                gem.AttractTo(transform);
                if (Vector3.Distance(transform.position, gem.transform.position) <= m_CollectDistance)
                {
                    _currencyManager.IncrementGemCount(gem.GemValue);
                    _currencyManager.IncrementScore();
                    _nearbyGems.RemoveAt(i);
                    Destroy(gem.gameObject);
                }
            }
        }
    
        public void ReduceGemCount(int amount)
        {
            _currencyManager.DecrementGemCount(amount);
        }
    }
}
