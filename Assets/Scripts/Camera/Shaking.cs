using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] AnimationCurve curve;
    float elapsedTime;

    public IEnumerator Shake()
    {
        elapsedTime = 0f;
        Vector3 startPos = transform.position;
        while(elapsedTime<duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPos;
    }
}
