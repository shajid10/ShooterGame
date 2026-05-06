using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 7f;
    [SerializeField] private float m_RotateSpeed = 10f;
    [SerializeField] private float m_DetectionRadius = 2f;

    [SerializeField] private Gun m_Gun;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private DynamicJoystick m_DynamicJoystick;

    private Transform _currentTarget = null;
    private bool _shooting = false;
    private bool _hasTarget = false;
    private CharacterController _characterController;
    
    private static readonly int HasTarget = Animator.StringToHash("hasTarget");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int X = Animator.StringToHash("x");
    private static readonly int Y = Animator.StringToHash("y");

    public static Player Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    private void Update() {
        HandleMovement();
        FindNearestEnemy();
        HandleShooting();
    }

    private void HandleMovement() {
        Vector2 inputVector = new Vector2(m_DynamicJoystick.Horizontal, m_DynamicJoystick.Vertical);
        if (inputVector.x != 0 || inputVector.y != 0) {
            m_Animator.SetBool(IsMoving, true);
        } else {
            m_Animator.SetBool(IsMoving, false);
        }
        inputVector.Normalize();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        Vector3 localMove = transform.InverseTransformDirection(moveDir);
        // Feed blend tree
        m_Animator.SetFloat(X, localMove.x);
        m_Animator.SetFloat(Y, localMove.z);

        //transform.position += moveDir * (m_MoveSpeed * Time.deltaTime);
        _characterController.Move(moveDir * (m_MoveSpeed * Time.deltaTime));
        if (!_shooting) {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * m_RotateSpeed);
        }
    }

    private void FindNearestEnemy() {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_DetectionRadius);

        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            if (!hit.CompareTag("Enemy")) continue;
            float distance = Vector3.Distance(transform.position, hit.transform.position);

            if (!(distance < closestDistance)) continue;
            _currentTarget = hit.transform;
            closestDistance = distance;
        }
    }

    private void HandleShooting() {
        if (_currentTarget) {
            _hasTarget = true;
            m_Animator.SetBool(HasTarget, _hasTarget);
            _shooting = true;
            m_Gun.SetShooting(true);

            Vector3 direction = _currentTarget.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * m_RotateSpeed);
        } else {
            _hasTarget = false;
            m_Animator.SetBool(HasTarget, _hasTarget);
            _shooting = false;
            m_Gun.SetShooting(false);
        }
    }

    public Gun GetGun()
    {
        return m_Gun;
    }
}

