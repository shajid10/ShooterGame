using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour {
    [SerializeField] private float m_MoveSpeed = 3f;

    private Transform _player;
    private Rigidbody _rb;
    private EnemyFlash _enemyFlash;
    private Vector3 _directionToPlayer;

    private void Start() {
        _player = GameObject.FindWithTag("Player").transform;
        _enemyFlash = GetComponent<EnemyFlash>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector3 direction = _player.position - transform.position;
        _directionToPlayer = new Vector3 (direction.x, 0, direction.z);
        _directionToPlayer.Normalize();

        _rb.Move(transform.position + _directionToPlayer * (m_MoveSpeed * Time.deltaTime), Quaternion.identity);
    }

    public void Hurt(int damage,  float knockback)
    {
        print("Hurt");
        _rb.AddForce(-_directionToPlayer * knockback, ForceMode.Impulse);
        _enemyFlash.Flash();
        transform.DOShakeScale(0.5f, new Vector3(0.1f, 0.1f, 0.1f));
    }
}
