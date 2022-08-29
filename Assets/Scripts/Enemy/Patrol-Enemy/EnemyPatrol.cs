using UnityEngine;

namespace DeathLight.EnemyServices
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float patrolDistance;

        private Vector3 startPosition;
        private Rigidbody2D rb;
        private bool toRight;

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

        private void Patrol()
        {
            if (transform.position.x >= startPosition.x + patrolDistance)
            {
                toRight = false;
            }
            else if (transform.position.x <= startPosition.x - patrolDistance)
            {
                toRight = true;
            }

            if (toRight)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
