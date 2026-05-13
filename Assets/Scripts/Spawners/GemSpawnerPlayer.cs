using System;
using DG.Tweening;
using ShooterGame.Data;
using UnityEngine;

namespace ShooterGame.Spawners
{
    public class GemSpawnerPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject m_GemVisual;
        [SerializeField] private GemData m_GemData;
        [SerializeField] private float m_SpawnInterval = 0.3f;
        
        private CurrencyManager _currencyManager;
        
        public event Action<TurretBuy> GemDumpedEvent;
        
        private bool _hasTargetZone = false;
        private TurretBuy _turretBuyZone;
        
        private float _timeElapsed = 0f;

        private void Start()
        {
            _currencyManager = CurrencyManager.Instance;
        }

        // =================================== ON TRIGGER ==================================
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BuyLocation"))
            {
                _hasTargetZone = true;
                _turretBuyZone = other.GetComponent<TurretBuy>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("BuyLocation"))
            {
                _hasTargetZone = false;
                _turretBuyZone = null;
            }
        }
        // =================================== GEM SPAWNING ==================================

        private void Update()
        {
            if (_hasTargetZone)
            {
                _timeElapsed += Time.deltaTime;
                if (_timeElapsed >= m_SpawnInterval)
                {
                    if (CanSpawnGem())
                        SpawnGem();
                    _timeElapsed = 0f;
                }
            }
        }

        private void SpawnGem()
        {
            if (!_turretBuyZone || !_turretBuyZone.CanReceiveGem())
                return;
            
            _turretBuyZone.ExpectGem(_currencyManager.GetGemValue());
            _currencyManager.DecrementGemCount(_currencyManager.GetGemValue());
            
            GameObject gemVisual = Instantiate(m_GemVisual.gameObject, transform.position, Quaternion.identity);
            gemVisual.transform.DOJump(_turretBuyZone.transform.position, 3f, 1, 0.5f).OnComplete(() =>
            {
                if (_turretBuyZone)
                    GemDumpedEvent?.Invoke(_turretBuyZone);
                Destroy(gemVisual);
            }).SetLink(gemVisual);
        }

        private bool CanSpawnGem()
        {
            if (_currencyManager.GetCurrentGemCount() >= _currencyManager.GetGemValue()
                && _turretBuyZone
                && _turretBuyZone.CanReceiveGem())
            {
                return true;
            }

            return false;
        }
    }
}
