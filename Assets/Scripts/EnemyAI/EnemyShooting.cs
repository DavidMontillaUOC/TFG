using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    [SerializeField] Transform targetPosition;
    Vector2 moveDirection;

    public float bulletShootInterval = 1f;

    private Coroutine shootingCoroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (targetPosition)
        {
            Vector3 direction = (targetPosition.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPosition = collision.transform;
            StartShooting();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPosition = null;
            StopShooting();
        }
    }

    private void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootBullets());
        }
    }

    private void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    IEnumerator ShootBullets()
    {
        while (true)
        {
            if (bulletPrefab != null && bulletSpawnPoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
                if (bulletMovement != null)
                {
                    Vector2 direction = (targetPosition.position - bulletSpawnPoint.position).normalized;
                    bulletMovement.SetDirection(direction);
                }
            }
            yield return new WaitForSeconds(bulletShootInterval);
        }
    }
}