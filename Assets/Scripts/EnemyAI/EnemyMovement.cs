using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float enemySpeed;

    [SerializeField]  Transform targetPosition;

    [SerializeField] float moveSpeed = 5.0f;

    Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }

    // Start is called before the first frame update
    void Start()
    {
        //targetPosition= GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPosition) 
        { 
            Vector3 direction = (targetPosition.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate() 
    {
        if (targetPosition) 
        { 
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }



    public void MoveTowardsTarget(Vector2 targetPos) {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPosition = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPosition = null;
        }
    }
}
