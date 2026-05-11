using UnityEngine;

namespace ShooterGame.Weapons
{
    public class Bullet : MonoBehaviour {
        [SerializeField] private float m_Speed = 12f;
        [SerializeField] private float m_TimeToLive = 3f;
        [SerializeField] private float m_Knockback = 2f;
        [SerializeField] private GameObject m_BulletImpactParticle;

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
                enemy.Hurt(_damage, m_Knockback);
                Instantiate(m_BulletImpactParticle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    
        public void SetBulletDamage(int damage) {
            _damage = damage;
        }
    }
}
