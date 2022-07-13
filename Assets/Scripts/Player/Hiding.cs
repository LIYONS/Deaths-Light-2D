using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] Transform frontCheck;
    [SerializeField] Transform backCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] GameObject eyes;
    private void Update()
    {
        if (Physics2D.OverlapCircle(frontCheck.position, 0.2f, ground) || Physics2D.OverlapCircle(backCheck.position, 0.2f, ground))
        {
            eyes.SetActive(false);
        }
        else
        {
            eyes.SetActive(true);
        }
    }
}
