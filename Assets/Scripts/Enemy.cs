using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float m_MoveSpeed = 3f;
    private Transform _player;
    private Rigidbody _rb;

    private void Start() {
        _player = GameObject.FindWithTag("Player").transform;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector3 direction = _player.position - transform.position;
        Vector3 playerDirection = new Vector3 (direction.x, 0, direction.z);
        playerDirection.Normalize();


        _rb.Move(transform.position + playerDirection * (m_MoveSpeed * Time.deltaTime), Quaternion.identity);
    }
}
