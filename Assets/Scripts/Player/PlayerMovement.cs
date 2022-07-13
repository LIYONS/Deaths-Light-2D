using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float fallMultiplier;
    [SerializeField] ParticleSystem JumpPs;
    bool facingRight;

    private void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);
        JumpUpdate(horizontal);
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
        if(rb.velocity.y!=0)
        {
            rb.velocity = new Vector2(horizontal *0.5f* playerSpeed, rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);
    }


    void Jump()
    {
        rb.velocity += new Vector2(0, jumpForce);
        JumpPs.Play();
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    void JumpUpdate(float horizontal)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (rb.velocity.y<0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else
        {
            rb.gravityScale = 2f;
        }
    }
}
