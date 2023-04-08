using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public enum Sound { PlayerLaser, EnemyLaser, Explosion };

    [SerializeField] AudioClip playerLaser;
    [SerializeField] AudioClip enemyLaser;
    [SerializeField] AudioClip explosion;

    private float playerLaserVolume = 0.1f;
    private float enemyLaserVolume = 0.1f;
    private float explosionVolume = 0.4f;


    public void Play(Sound sound) {
        switch (sound) {
            case Sound.PlayerLaser:
                PlayClip(playerLaser, playerLaserVolume);
                break;
            case Sound.EnemyLaser:
                PlayClip(enemyLaser, enemyLaserVolume);
                break;
            case Sound.Explosion:
                PlayClip(explosion, explosionVolume);
                break;
        }
    }

    private void PlayClip(AudioClip clip, float volume) {
        if (clip != null) {
            Vector3 camPOS = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camPOS, volume);
        }
    }

}
