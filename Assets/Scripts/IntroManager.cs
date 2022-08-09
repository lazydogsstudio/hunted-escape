using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public int introSize;


    void Start()
    {
        StartCoroutine(LoadMainMenu(introSize));
    }



    IEnumerator LoadMainMenu(int sec)
    {
        yield return new WaitForSeconds(sec);
        SceneLoader.instance.LoadScene("MainMenu");
    }
}
