using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;

    public AudioClip enemyChaseAudio;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    public void PlayCustomAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayEnemyChaseSound()
    {
        audioSource.PlayOneShot(enemyChaseAudio);

    }



}
