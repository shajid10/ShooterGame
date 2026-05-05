using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float m_InitialForceMultiplier = 5f;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Vector3 initialDirection =  transform.forward * Random.Range(-0.5f, 0.5f)
                                   + transform.right * Random.Range(-0.5f, 0.5f);
        initialDirection = initialDirection.normalized *  m_InitialForceMultiplier;
        _rb.AddForce(initialDirection, ForceMode.Impulse);
    }

}
