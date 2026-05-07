using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float m_Acceleration = 25f;
    [SerializeField] private GemSO m_GemSO;

    private int _gemValue;
    private Transform _target;
    private float _currentSpeed;
    
    private Rigidbody _rigidbody;

    public int GemValue => _gemValue;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _gemValue = m_GemSO.Value; 
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