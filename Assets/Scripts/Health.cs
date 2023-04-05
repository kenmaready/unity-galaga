using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damager = other.GetComponent<DamageDealer>();

        if (damager != null) {
            TakeDamage(damager.GetDamage());
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
}
