using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float attackDelay = .5f;
    float timer = 0f;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && timer<Time.time)
        {
            Hiding hiding = other.gameObject.GetComponent<Hiding>();
            if (!hiding.isHiding)
            {
                PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
                playerMovement.Death();
                timer = Time.time + attackDelay;
            }
        }
    }
}
