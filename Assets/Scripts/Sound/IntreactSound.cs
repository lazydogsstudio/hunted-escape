using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntreactSound : MonoBehaviour
{

    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // AudioManager.instance.PlayCustomAudio(audioClip);
        }
    }
}
