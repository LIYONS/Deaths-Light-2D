using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] Transform frontCheck;
    [SerializeField] float radius;
    [SerializeField] Transform backCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] GameObject eyes;
    [HideInInspector]
    public bool isHiding;

    private void Start()
    {
        isHiding = false;
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(frontCheck.position, 0.2f, ground) || Physics2D.OverlapCircle(backCheck.position, radius, ground))
        {
            isHiding = true;
            eyes.SetActive(false);
        }
        else
        {
            isHiding = false;
            eyes.SetActive(true);
        }
    }
}
