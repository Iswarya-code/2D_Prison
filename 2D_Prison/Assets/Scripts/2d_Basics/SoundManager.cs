using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip shootSound;
    public AudioClip popupSound;
    public AudioClip policeGunshotSound;   // Assign a police gunshot sound


    private void Awake()
    {
        // Ensure only one SoundManager exists (Singleton)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this across scene loads
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Plays any AudioClip passed in
    public void PlaySound(AudioClip clip)
    {
        if (audioSource && clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Specifically play the shoot sound
    public void PlayShootSound()
    {
        PlaySound(shootSound);
    }

    // Specifically play the popup sound
    public void PlayPopupSound()
    {
        PlaySound(popupSound);
    }

    public void PlayPoliceGunshot()
    {
        PlaySound(policeGunshotSound);
    }
}
