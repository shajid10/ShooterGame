using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float m_TimeToLive = 3f;

    private void Start() {
        Destroy(gameObject, m_TimeToLive);
    }

    private void FixedUpdate() {
        transform.position += transform.forward * (m_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            print(other.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
