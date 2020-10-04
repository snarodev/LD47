using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AnimationCurve scalingAnim;

    public float animationDuration = 5;

    Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        float value = scalingAnim.Evaluate((Time.time / animationDuration) % 1);


        transform.localScale = originalScale * value;
    }
}
