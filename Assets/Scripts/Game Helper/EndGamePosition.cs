using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePosition : MonoBehaviour
{

    private int _winTimes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.IncrementWinTimes();
            PlayerPrefs.SetInt("win", 0);
            VideoManager.instance.PlayEndVideo();
        }
    }
   
}
