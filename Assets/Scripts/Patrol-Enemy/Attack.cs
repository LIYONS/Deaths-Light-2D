using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Hiding hiding = other.gameObject.GetComponent<Hiding>();
            if(!hiding.isHiding)
            {
                PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
                playerMovement.Death();
            }       
        }
    }
}
