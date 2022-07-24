using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;


    public AudioSource enemyChaseSound;
    public AudioSource backGroundSound;

    public AudioClip enemyChaseAudio;


    public enum BGState
    {

    }


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



}
