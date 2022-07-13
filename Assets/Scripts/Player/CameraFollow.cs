using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    float offsetX;
    float offsetY;

    private void Start()
    {
        if(player)
        {
            offsetX = transform.position.x - player.transform.position.x;
            offsetY = transform.position.y - player.transform.position.y;
        }
    }

    private void Update()
    {
        if(player)
        {
            transform.position = new Vector3(player.transform.position.x - offsetX, player.transform.position.y-offsetY, transform.position.z);
        }
    }
}
