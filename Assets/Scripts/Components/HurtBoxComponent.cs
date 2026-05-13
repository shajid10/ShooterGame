using System.Collections;
using ShooterGame.Components;
using UnityEngine;

namespace Components
{
    public class HurtBoxComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent m_Health;
        [SerializeField] private string m_OpponentTag;
        
        private Coroutine _hurtCoroutine;
              
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(m_OpponentTag))
            {
                int damage = 0;
                HitBoxComponent hitbox =  other.GetComponentInParent<HitBoxComponent>();
                if (hitbox)
                    damage = hitbox.Damage;
                print(damage);
                
                if (_hurtCoroutine != null) return;
                _hurtCoroutine = StartCoroutine(GetHurt(damage));
            }
        }

        private IEnumerator GetHurt(int damage)
        {
            m_Health.ReduceHealth(damage);
            yield return new WaitForSeconds(0.4f);
            _hurtCoroutine = null;
        }
    }
}
