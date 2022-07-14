using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float fallMultiplier;
    [SerializeField] ParticleSystem JumpPs;
    [SerializeField] float jumpCount;
    [SerializeField] float jumpDelay;
    [SerializeField] GameObject deathPs;
    [SerializeField] Menu menu;
    float jumpCheck;
    Rigidbody2D rb;
    bool facingRight;
    float jumpTimer;

    private void Start()
    {
        jumpCheck = 0f;
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
        if (jumpCheck < jumpCount && jumpTimer<Time.time)
        {
            rb.velocity += new Vector2(0, jumpForce);
            JumpPs.Play();
            jumpCheck++;
            if(jumpCheck==jumpCount)
            {
                jumpTimer = Time.time + jumpDelay;
                jumpCheck = 0f;
            }
        }
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
    public void Death()
    {
        menu.GameOver();
        GameObject DeathPs= Instantiate(deathPs, transform.position,Quaternion.identity) as GameObject;
        gameObject.SetActive(false);
    }
}
