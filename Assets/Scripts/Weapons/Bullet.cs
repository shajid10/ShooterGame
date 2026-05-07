using System;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float m_TimeToLive = 3f;
    [SerializeField] private float m_Knockback = 2f;
    [SerializeField] private int m_BulletDamage = 20;
    [SerializeField] private GameObject m_BulletImpactParticle;

    private void Start() {
        Destroy(gameObject, m_TimeToLive);
    }

    private void FixedUpdate() {
        transform.position += transform.forward * (m_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            enemy.Hurt(m_BulletDamage, m_Knockback);
            Instantiate(m_BulletImpactParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
