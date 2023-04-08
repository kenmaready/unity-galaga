using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool isPlayer = false;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] bool applyShake;
    CameraShake cameraShake;
    AudioPlayer sfx;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        sfx = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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

    public int GetHealth() {
        return health;
    }

    void TakeDamage(int damage) {
        health -= damage;
        if (!isPlayer) {
            scoreKeeper.Add(50);
        } else {
            scoreKeeper.Add(-50);
        }
        // Debug.Log("Your health is now: " + health);
        if (health <= 0) {
            if (!isPlayer) {
                scoreKeeper.Add(50);
            }
            Destroy(gameObject);
        }
    }

    void Explode() {
        if (explosion != null) {
            ParticleSystem instance = Instantiate(explosion, transform.position, Quaternion.identity);
            sfx.Play(AudioPlayer.Sound.Explosion);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera() {
        if (cameraShake != null && applyShake) {
            cameraShake.Play();
        }
    }
}
