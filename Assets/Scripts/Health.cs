using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    [SerializeField] AudioClip boomClip;
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 50;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();   
        audioPlayer = FindObjectOfType<AudioPlayer>(); 
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public int GetHealth() => health;

    private void OnTriggerEnter2D(Collider2D other) {
        Damage damageDealer = other.GetComponent<Damage>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        audioPlayer.PlayDamageClip(boomClip);
        if (health <= 0)
        {
            if (! isPlayer)
            {
                scoreKeeper.ModifyCurrentScore(score);
            }
            Destroy(gameObject);
        }
    }
    private void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
