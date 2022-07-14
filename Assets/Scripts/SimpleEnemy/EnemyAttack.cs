using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float waitTime=1f;
    float timer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.Death();
            timer = waitTime + Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (timer < Time.time)
            {
                PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
                playerMovement.Death();
                timer = waitTime + Time.time;
            }
        }
    }
}
