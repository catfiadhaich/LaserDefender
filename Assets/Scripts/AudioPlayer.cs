using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 0.5f;

    public void PlayShootingClip(AudioClip clip)
    {
        PlayClip(clip, shootingVolume);
    }
        public void PlayDamageClip(AudioClip clip)
    {
        PlayClip(clip, shootingVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(clip, 
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
