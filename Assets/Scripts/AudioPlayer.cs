using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] AudioClip playerLaser;
    [SerializeField] AudioClip enemyLaser;
    [SerializeField] AudioClip explosion;

    private float playerLaserVolume = 0.2f;
    private float enemyLaserVolume = 0.3f;
    private float explosionVolume = 0.4f;

    public void PlayerLaser() {
        if (playerLaser != null) {
            AudioSource.PlayClipAtPoint(playerLaser, Camera.main.transform.position, playerLaserVolume);
        }
    }

    public void EnemyLaser() {
        if (enemyLaser != null) {
            AudioSource.PlayClipAtPoint(enemyLaser, Camera.main.transform.position, enemyLaserVolume);
        }
    }

    public void Explosion(bool loud = false) {
        float vol = (loud ? explosionVolume * 2 : explosionVolume);
        AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position, explosionVolume);
    }

}
