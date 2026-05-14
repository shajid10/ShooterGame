using ShooterGame.Player;
using ShooterGame.Components;
using ShooterGame.Data;
using ShooterGame.Weapons;
using UnityEngine;

namespace ShooterGame.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float m_MoveSpeed = 7f;
        [SerializeField] private float m_RotateSpeed = 10f;

        [SerializeField] private Gun m_Gun;
        [SerializeField] private Animator m_Animator;

        [SerializeField] private UpgradeData m_PlayerUpgradeData;

        private Transform _currentTarget = null;
        private bool _shooting = false;
        private bool _hasTarget = false;
        private bool _isDead = false;
        private CharacterController _characterController;
        private GemCollector _gemCollector;
        private EnemyDetector _enemyDetector;
        private HealthComponent _health;
    
        private static readonly int HasTarget = Animator.StringToHash("hasTarget");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private static readonly int X = Animator.StringToHash("x");
        private static readonly int Y = Animator.StringToHash("y");
        private static readonly int OnDeath = Animator.StringToHash("OnDeath");

        public static Player Instance {get; private set;}

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _gemCollector = GetComponentInChildren<GemCollector>();
            _enemyDetector = GetComponentInChildren<EnemyDetector>();
            _health = GetComponent<HealthComponent>();
            
            m_PlayerUpgradeData.UpgradeCompleteEvent += OnPlayerUpgradeDataCompleteEvent;
            _health.DeathEvent += OnPlayerDeath;
        
            m_Gun.SetDamage(m_PlayerUpgradeData.m_Damage);
        }

        private void OnPlayerDeath()
        {
            _isDead = true;
            m_Gun.SetShooting(false);
            m_Animator.SetTrigger(OnDeath);
            
            //gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            m_PlayerUpgradeData.UpgradeCompleteEvent -= OnPlayerUpgradeDataCompleteEvent;
        }

        private void OnPlayerUpgradeDataCompleteEvent()
        {
            m_Gun.SetDamage(m_PlayerUpgradeData.m_Damage);
        }


        private void Update() {
            if (_isDead) return;
            HandleMovement();
            _currentTarget = _enemyDetector.GetNearestEnemy();
            HandleShooting();
        }

        private void HandleMovement() {
            Vector2 inputVector = InputController.Instance.GetInputVectorNormalized();
            if (inputVector.x != 0 || inputVector.y != 0) {
                m_Animator.SetBool(IsMoving, true);
            } else {
                m_Animator.SetBool(IsMoving, false);
            }

            Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
            Vector3 localMove = transform.InverseTransformDirection(moveDir);
            // Feed blend tree
            m_Animator.SetFloat(X, localMove.x);
            m_Animator.SetFloat(Y, localMove.z);

            _characterController.Move(moveDir * (m_MoveSpeed * Time.deltaTime));
            if (!_shooting) {
                transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * m_RotateSpeed);
            }
        }

        private void HandleShooting() {
            if (_currentTarget) {
                _hasTarget = true;
                m_Animator.SetBool(HasTarget, _hasTarget);
                _shooting = true;
                m_Gun.SetShooting(_shooting);

                Vector3 direction = _currentTarget.position - transform.position;
                direction.y = 0;
                direction.Normalize();
                transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * m_RotateSpeed);
            } else {
                _hasTarget = false;
                m_Animator.SetBool(HasTarget, _hasTarget);
                _shooting = false;
                m_Gun.SetShooting(_shooting);
            }
        }

        public Gun GetGun()
        {
            return m_Gun;
        }

        public bool IsDead()
        {
            return _isDead;
        }
    }
}

