using UnityEngine;

public class Bullet : MonoBehaviour {
    private float speed = 12f;

    private void FixedUpdate() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
