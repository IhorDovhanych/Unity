using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    public float scaleFactor = 1.5f;
    public float animationDuration = 1.0f;
    private Vector3 originalScale;

    void Start()
    { 
        originalScale = transform.localScale;
        StartCoroutine(ScaleObject());
    }

    IEnumerator ScaleObject()
    {
        while (true)
        {
            Vector3 targetScale = originalScale * scaleFactor;
            float timer = 0;

            while (timer < animationDuration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / animationDuration);
                timer += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScale;
            yield return new WaitForSeconds(0.2f);

            timer = 0;
            while (timer < animationDuration)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / animationDuration);
                timer += Time.deltaTime;
                yield return null;
            }

            transform.localScale = originalScale;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
