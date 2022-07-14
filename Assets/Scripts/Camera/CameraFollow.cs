using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    float offsetX;
    float offsetY;

    private void Start()
    {
        if(player)
        {
            offsetX = Mathf.Abs( transform.position.x - player.position.x);
            offsetY = Mathf.Abs( transform.position.y - player.position.y);
        }
    }

    private void Update()
    {
        if(player)
        {
            transform.position = new Vector3(player.position.x + offsetX, player.position.y+offsetY, transform.position.z);
        }
    }
}
