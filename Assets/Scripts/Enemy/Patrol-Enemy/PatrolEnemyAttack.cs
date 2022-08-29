using UnityEngine;
using DeathLight.Player;

namespace DeathLight.EnemyServices
{
    public class PatrolEnemyAttack : MonoBehaviour
    {
        [SerializeField] private float nextAttackDelay = .5f;

        private float timer = 0f;
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMovement>() && timer < Time.time)
            {
                Hiding hiding = other.GetComponent<Hiding>();
                if (!hiding.GetIsHiding)
                {
                    PlayerHealth playerHealth =other. GetComponent<PlayerHealth>();
                    playerHealth.TakeDamage();
                    timer = Time.time + nextAttackDelay;
                }
            }
        }
    }
}
