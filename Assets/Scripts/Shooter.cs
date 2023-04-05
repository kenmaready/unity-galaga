using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    private float speed = K.Projectile.Speed;
    private float life = K.Projectile.Life;
    private float baseFiringRate;
    private float firingRateVariance = 0f;
    private float minFiringRate = 0.1f;

    private Coroutine firingCoroutine;
    private bool isFiring;
    [SerializeField] private bool useAI;

    void Start()
    {
        if (useAI) { 
            isFiring = true;
            baseFiringRate = K.Enemy.FireRate;
            firingRateVariance = K.Enemy.FireVar;
            minFiringRate = K.Enemy.FireMin;
        } else {
            isFiring = false;
            baseFiringRate = K.Player.FireRate;
            firingRateVariance = 0f;
            minFiringRate = 0.1f;
        }
    }

    void Update()
    {
        Fire();
    }

    public void SetIsFiring(bool firing) {
        isFiring = firing;
    }

    void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously() {
        while (true) {
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity = (transform.up * speed);
            }

            Destroy(instance, life);
            yield return new WaitForSeconds(useAI ? Random.Range(Mathf.Max(minFiringRate, baseFiringRate - firingRateVariance), baseFiringRate + firingRateVariance) : baseFiringRate);
        }

    }
}

