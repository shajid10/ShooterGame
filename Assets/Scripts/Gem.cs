using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 10f;
    [SerializeField] private float m_Acceleration = 25f;

    private Transform _target;
    private float _currentSpeed;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void AttractTo(Transform target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        if (!_rigidbody.isKinematic && _rigidbody.IsSleeping())
        {
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
        }
    }

    private void Update()
    {
        if (!_target) return;
        _currentSpeed += m_Acceleration * Time.deltaTime;

        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.position,
            _currentSpeed * Time.deltaTime
        );
    }
}