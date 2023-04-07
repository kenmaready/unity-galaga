using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    private float duration = 0.5f;
    private float magnitude = 0.25f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void Play() {
        StartCoroutine(Shake());
    }

    IEnumerator Shake() {

        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            transform.position = startPosition + (Vector3)Random.insideUnitCircle * magnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();    
        }

        transform.position = startPosition;
    }
}
