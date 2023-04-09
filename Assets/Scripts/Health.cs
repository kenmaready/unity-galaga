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
    ScoreKeeper sk;
    LevelManager lm;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        sfx = FindObjectOfType<AudioPlayer>();
        sk = FindObjectOfType<ScoreKeeper>();
        lm = FindObjectOfType<LevelManager>();
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
            sk.Add(50);
        } else {
            sk.Add(-50);
        }
        // Debug.Log("Your health is now: " + health);
        if (health <= 0) {
            if (!isPlayer) {
                sk.Add(50);
            } else {
                lm.LoadGameOverMenu();
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
