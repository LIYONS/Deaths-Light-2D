using UnityEngine;

namespace DeathLight.Player
{
    public class FallDeath : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerMovement>()!=null)
            {
                collision.GetComponent<PlayerHealth>().Death();
            }
        }
    }
}
