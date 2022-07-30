using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager instance;
    public GameObject UIPanel;
    public GameObject videoObject;

    [Header("Ending Video")]
    public VideoClip endingVideoClip;
    public float endingVideoLength;



    private VideoPlayer _videoPlayer;

    void Awake()
    {
        instance = this;
    }


    void PlayVideo(bool value)
    {
        if (value)
        {
            UIPanel.SetActive(false);
            AudioManager.instance.playBackGroundSound(false);
            videoObject.SetActive(true);
        }
        else
        {
            UIPanel.SetActive(true);
            AudioManager.instance.playBackGroundSound(true);
            videoObject.SetActive(false);
        }
    }

    IEnumerator ExitVideo(float seconds, bool changeScene = false, string sceneName = "")
    {
        yield return new WaitForSeconds(seconds);
        PlayVideo(false);

        if (changeScene)
            SceneLoader.instance.LoadScene(sceneName);

    }


    void SetVideo(VideoClip clip)
    {
        _videoPlayer = videoObject.GetComponent<VideoPlayer>();
        _videoPlayer.clip = clip;
    }


    public void PlayEndVideo()
    {
        SetVideo(endingVideoClip);
        PlayVideo(true);
        StartCoroutine(ExitVideo(endingVideoLength, true, "MainMenu"));
    }
}
