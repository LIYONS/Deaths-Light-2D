using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float waitTime;

    private void Update()
    {
        if(Time.time>waitTime)
        {
            Destroy(gameObject);
        }
    }

}
