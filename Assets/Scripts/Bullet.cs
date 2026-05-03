using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed = 12f;
    [SerializeField] private float timeToLive = 3f;

    private void Start() {
        Destroy(gameObject, timeToLive);
    }

    private void FixedUpdate() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(this);
        }
    }
}
