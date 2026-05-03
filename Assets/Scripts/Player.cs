using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float detectionRadius = 2f;

    [SerializeField] private Gun gun;
    [SerializeField] private Animator animator;

    private Transform currentTarget = null;
    bool shooting = false;
    bool isMoving = false;
    private void Update() {
        HandleMovement();
        FindNearestEnemy();
        HandleShooting();
    }

    private void HandleMovement() {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (inputVector.sqrMagnitude > 0f) {
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
        inputVector.Normalize();
            Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        if (!shooting) {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
    }

    private void FindNearestEnemy() {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits) {
            if (hit.CompareTag("Enemy")) {
                float distance = Vector3.Distance(transform.position, hit.transform.position);

                if (distance < closestDistance) {
                    currentTarget = hit.transform;
                    closestDistance = distance;
                }
            }
        }
    }

    private void HandleShooting() {
        if (currentTarget != null) {
            shooting = true;
            gun.SetShooting(true);

            Vector3 direction = currentTarget.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        } else {
            shooting = false;
            gun.SetShooting(false);
        }
    }
}

