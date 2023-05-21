using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Vector2 direction;
    public float bulletLifetime = 10f;

    void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        MoveBullet();
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void MoveBullet()
    {
        Vector2 movement = direction * bulletSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Bullethit");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(10);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject);
    }
}