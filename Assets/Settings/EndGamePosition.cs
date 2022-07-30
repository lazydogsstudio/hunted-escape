using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePosition : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VideoManager.instance.PlayEndVideo();
        }
    }
}
