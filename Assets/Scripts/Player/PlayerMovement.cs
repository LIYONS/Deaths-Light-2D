using UnityEngine;

namespace DeathLight.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float fallGravityMultiplier;
        [SerializeField] private ParticleSystem JumpPs;
        [SerializeField] private float maxJumpCount;
        [SerializeField] private float nextJumpDelay;
        [SerializeField] private float jumpSpeedMultiplier;

        private float jumped;
        private Rigidbody2D rigidBody;
        private bool facingRight;
        private float timer;

        private void Start()
        {
            jumped = maxJumpCount;
            facingRight = true;
            rigidBody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            
            Movement();
            JumpUpdate();
        }
        private void Movement()
        {
            float movementInput = Input.GetAxis("Horizontal");
            if (movementInput > 0 && !facingRight)
            {
                Flip();
            }
            else if (movementInput < 0 && facingRight)
            {
                Flip();
            }
            if (rigidBody.velocity.y != 0)
            {
                rigidBody.velocity = new Vector2(movementInput * jumpSpeedMultiplier * playerSpeed, rigidBody.velocity.y);
                return;
            }
            rigidBody.velocity = new Vector2(movementInput * playerSpeed, rigidBody.velocity.y);
        }


        private void Jump()
        {
            if (jumped >=0 && timer < Time.time)
            {
                rigidBody.velocity += new Vector2(0, jumpForce);
                JumpPs.Play();
                jumped--;
                if (jumped <=0)
                {
                    timer = Time.time + nextJumpDelay;
                    jumped = maxJumpCount;
                }
            }
        }
        private void Flip()
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        private void JumpUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.gravityScale = fallGravityMultiplier;
            }
            else
            {
                rigidBody.gravityScale = 2f;
            }
        }
    }
}
