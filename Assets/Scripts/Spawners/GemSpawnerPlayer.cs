using System;
using DG.Tweening;
using UnityEngine;

public class GemSpawnerPlayer : MonoBehaviour
{
    // player detects dump zone using OnTrigger
    // Get position of dump zone
    // At a certain interval
        // Spawn gem and jumptween to dump zone using DOTween
        // OnTweenComplete invoke an event to let dumpzone know
        // when spawning gem, 
        [SerializeField] private GameObject m_GemVisual;
        [SerializeField] private GemSO m_GemSo;
        [SerializeField] private float m_SpawnInterval = 0.3f;
        
        public event Action<TurretBuy> GemDumpedEvent;
        
        private bool _hasTargetZone = false;
        private TurretBuy _turretBuyZone;
        
        private float _timeElapsed = 0f;
        private Player _player;

        private void Start()
        {
            _player = Player.Instance;
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
            _player.ReduceGemCount(m_GemSo.m_Value);
            
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
            if (_player.GetGemCount() >= m_GemSo.m_Value 
                && _turretBuyZone
                   && _turretBuyZone.CanReceiveGem())
            {
                return true;
            }

            return false;
        }
}
