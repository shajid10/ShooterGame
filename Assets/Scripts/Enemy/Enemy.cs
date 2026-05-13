using ShooterGame.Components;
using UnityEngine;
using DG.Tweening;
using ShooterGame.Player;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    private static readonly int HasTarget = Animator.StringToHash("hasTarget");
    
    [SerializeField] private float m_MoveSpeed = 3f;
    [SerializeField] private ParticleSystem m_DeathParticles;
    [SerializeField] private Gem m_Gem;
    
    [SerializeField] private Animator  m_Animator; 
    private Vector3 _directionToPlayer;

    private NavMeshAgent _navAgent;
    private Player _player;
    private Rigidbody _rb;
    private EnemyFlash _enemyFlash;
    private HealthComponent _health;

    private void Start() {
        _player = Player.Instance;
        _enemyFlash = GetComponent<EnemyFlash>();
        _navAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _health = GetComponent<HealthComponent>();
        
        _navAgent.speed = m_MoveSpeed;
        
        _health.DeathEvent += OnDeath;
    }
    

    private void Update() {
        if (_player && !_player.IsDead())
            _navAgent.SetDestination(_player.transform.position);
        else
        {
            _navAgent.speed = 0;
            m_Animator.SetBool(HasTarget, false);
        }
    }

    public void Hurt(int damage,  float knockback)
    {
        if (_rb)
            _rb.AddForce(-_directionToPlayer * knockback, ForceMode.Impulse);
        _enemyFlash.Flash();
        transform.DOShakeScale(0.5f, new Vector3(0.1f, 0.1f, 0.1f)).SetLink(gameObject);
        _health.ReduceHealth(damage);
    }
    
    private void OnDeath()
    {
        Instantiate(m_DeathParticles, transform.position, Quaternion.identity);
        Instantiate(m_Gem, transform.position, Quaternion.identity);
        m_DeathParticles.Play();
        Destroy(gameObject);
    }

    public void SetMaxHealth(int maxHealth)
    {
        _health.SetMaxHealth(maxHealth);
    }

    private void OnDestroy()
    {
        _health.DeathEvent -= OnDeath;
    }
}
