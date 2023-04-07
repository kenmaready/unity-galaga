using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explosion;

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damager = other.GetComponent<DamageDealer>();

        if (damager != null) {
            TakeDamage(damager.GetDamage());
            Explode();
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
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
