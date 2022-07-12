using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    bool facingRight;

    private void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetFloat("verticalSpeed", rb.velocity.y);
            Jump();
        }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);

    }

    void Movement(float horizontal)
    {
        if(horizontal>0 && !facingRight)
        {
            Flip();
        }
        else if(horizontal<0 && facingRight)
        {
            Flip();
        }
        rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);
    }


    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
