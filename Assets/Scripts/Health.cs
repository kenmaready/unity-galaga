using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] bool applyShake;
    CameraShake cameraShake;
    AudioPlayer audio;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audio = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damager = other.GetComponent<DamageDealer>();

        if (damager != null) {
            TakeDamage(damager.GetDamage());
            Explode();
            ShakeCamera();
            damager.Destroy();
        }
    }

    void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Your health is now: " + health);
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void Explode() {
        if (explosion != null) {
            ParticleSystem instance = Instantiate(explosion, transform.position, Quaternion.identity);
            audio.Explosion();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera() {
        if (cameraShake != null && applyShake) {
            cameraShake.Play();
        }
    }
}
