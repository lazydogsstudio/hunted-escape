using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;


    public AudioSource enemyChaseSound;
    public AudioSource backGroundSound;

    public AudioClip enemyChaseAudio;



    [Header("Doors")]
    public AudioSource playerFootStepSound;
    public bool isPlayerfootStepSoundPlaying;

    [Header("Doors")]
    public AudioClip doorOpenSound;
    public AudioClip doorLockedSound;

    [Header("Pickup & Drop")]
    public AudioClip pickUpSound;
    public AudioClip dropSound;


    [Header("Voice Over")]

    public AudioClip redRoomVoiceOver;
    public AudioClip topFloorVoiceOver;
    public AudioClip controllRoomVoiceOver;

    [Header("Gun")]
    public AudioClip fireSound;


    void Awake()
    {
        instance = this;

    }

    public void PlayEnemyChaseSound(bool value)
    {
        if (value)
            enemyChaseSound.Play();
        else
            enemyChaseSound.Stop();
    }


    public void playBackGroundSound(bool value)
    {
        if (value)
            backGroundSound.Play();
        else
            backGroundSound.Stop();
    }


    // Door Sounds
    public void PlayDoorOpenSound()
    {
        audioSource.PlayOneShot(doorOpenSound);
    }
    public void PlayDoorLockedSound()
    {
        audioSource.PlayOneShot(doorLockedSound);
    }


    // Pick up & Drop
    public void PlayDropSound()
    {
        audioSource.PlayOneShot(dropSound);
    }
    public void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickUpSound);
    }



    ////////////////////////// Voice Overs Audio Controll ///////////////////////////


    public void PlayRedRoomVoiceOver()
    {
        audioSource.PlayOneShot(redRoomVoiceOver);
    }
    public void PlayTopFloorVoiceOver()
    {
        audioSource.PlayOneShot(topFloorVoiceOver);
    }

    public void PlayControllRoomVoiceOver()
    {
        audioSource.PlayOneShot(controllRoomVoiceOver);
    }


    public void PlayFireSound()
    {
        audioSource.PlayOneShot(fireSound);
    }


    public void PlayCustomAudio(AudioClip value)
    {
        audioSource.PlayOneShot(value);
    }
}
