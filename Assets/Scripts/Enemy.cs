using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float moveSpeed = 3f;
    private Transform player;
    private Rigidbody rb;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector3 direction = player.position - transform.position;
        Vector3 playerDirection = new Vector3 (direction.x, 0, direction.z);
        playerDirection.Normalize();


        rb.Move(transform.position + playerDirection * moveSpeed * Time.deltaTime, Quaternion.identity);
    }
}
