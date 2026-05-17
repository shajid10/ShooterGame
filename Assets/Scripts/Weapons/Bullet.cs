using UnityEngine;

namespace ShooterGame.Weapons
{
    public class Bullet : MonoBehaviour {
        [SerializeField] private float m_Speed = 12f;
        [SerializeField] private float m_TimeToLive = 3f;
        [SerializeField] private GameObject m_BulletImpactParticle;

        private float _knockback;
        private int _damage = 20;
    
        private void Start() {
            Destroy(gameObject, m_TimeToLive);
        }

        private void FixedUpdate() {
            transform.position += transform.forward * (m_Speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Enemy")) {
                Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
                enemy.GetHurt(_damage, _knockback);
                Instantiate(m_BulletImpactParticle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    
        public void SetBulletDamage(int damage) {
            _damage = damage;
        }

        public void SetKnockback(float knockback)
        {
            _knockback = knockback;
        }
    }
}
