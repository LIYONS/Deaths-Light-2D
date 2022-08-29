using UnityEngine;
using DeathLight.Player;

namespace DeathLight.EnemyServices
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float nextAttackDelay = 1f;

        private float timer;

        private void Start()
        {
            timer = nextAttackDelay;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage();
                timer = nextAttackDelay + Time.time;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                if (timer < Time.time)
                {
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    playerHealth.TakeDamage();
                    timer = nextAttackDelay + Time.time;
                }
            }
        }
    }
}
