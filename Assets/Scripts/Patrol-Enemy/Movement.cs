using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float patrolDistance;
    Vector3 startPosition;
    Rigidbody2D rb;
    bool toRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        toRight = true;
    }
    private void FixedUpdate()
    {
       Patrol();
    }

    void Patrol()
    {
        if(transform.position.x>=startPosition.x+patrolDistance)
        {
            toRight = false;
        }
        else if(transform.position.x<=startPosition.x-patrolDistance)
        {
            toRight = true;
        }

        if(toRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
