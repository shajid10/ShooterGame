using UnityEngine;

public class Gun : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float timeInterval = 0.8f;

    float timeRemaining = 0f;
    bool isShooting = true;

    private void Start() {
        timeRemaining = timeInterval;
    }

    private void Update() {
        if (isShooting) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            } else {
                Shoot();

                timeRemaining = timeInterval;
            }
        }
    }

    private void Shoot() {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
