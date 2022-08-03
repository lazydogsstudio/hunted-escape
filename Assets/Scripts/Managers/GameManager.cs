using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int winTimes;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        winTimes = PlayerPrefs.GetInt("WinTimes");

    }

    public void IncrementWinTimes()
    {
        PlayerPrefs.SetInt("WinTimes", winTimes + 1);
    }

    public int GetWinTimes()
    {
        return PlayerPrefs.GetInt("WinTimes");
    }




}
