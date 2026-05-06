using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [SerializeField] private float m_MoveSpeed = 3f;
    [SerializeField] private ParticleSystem m_DeathParticles;
    [SerializeField] private Gem m_Gem;
    private Vector3 _directionToPlayer;

    private NavMeshAgent _navAgent;
    private Transform _playerTransform;
    private Rigidbody _rb;
    private EnemyFlash _enemyFlash;
    private HealthComponent _health;

    private void Start() {
        _playerTransform = FindAnyObjectByType<Player>().transform;
        _enemyFlash = GetComponent<EnemyFlash>();
        _navAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _health = GetComponent<HealthComponent>();
        
        _navAgent.speed = m_MoveSpeed;
        
        _health.EnemyDeathEvent += OnEnemyDeathEvent;
    }
    

    private void Update() {
        _navAgent.SetDestination(_playerTransform.position);
    }

    public void Hurt(int damage,  float knockback)
    {
        _rb.AddForce(-_directionToPlayer * knockback, ForceMode.Impulse);
        _enemyFlash.Flash();
        transform.DOShakeScale(0.5f, new Vector3(0.1f, 0.1f, 0.1f)).SetLink(gameObject);
        _health.ReduceHealth(damage);
    }
    
    private void OnEnemyDeathEvent(object sender, EventArgs e)
    {
        Instantiate(m_DeathParticles, transform.position, Quaternion.identity);
        Instantiate(m_Gem, transform.position, Quaternion.identity);
        m_DeathParticles.Play();
        Destroy(gameObject);
    }
}
