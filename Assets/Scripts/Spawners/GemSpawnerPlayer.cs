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
        [SerializeField] private GemVisual m_GemVisual;
        
        private bool _hasTargetZone = false;
        private TurretBuy _turretBuyZone;
        
        private float _spawnInterval = 0.3f;
        private float _timeElapsed = 0f;

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
                if (_timeElapsed >= _spawnInterval)
                {
                    SpawnGem();
                    _timeElapsed = 0f;
                }
            }
        }

        private void SpawnGem()
        {
            GameObject gemVisual = Instantiate(m_GemVisual.gameObject, transform.position, Quaternion.identity);
            gemVisual.transform.DOJump(_turretBuyZone.transform.position, 3f, 1, 0.5f).OnComplete(() =>
            {
                Destroy(gemVisual);
            }).SetLink(gemVisual);
        }
}
