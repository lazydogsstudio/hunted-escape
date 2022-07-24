using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _hudPanel;
    [SerializeField] private GameObject _gameoverPanel;

    private void Awake()
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
        _settingPanel.SetActive(false);
        AudioManager.instance.playBackGroundSound(true);
    }

    public void SetHUDPanel(bool value)
    {
        _hudPanel.SetActive(value);
    }

    public void SetSettingPanel(bool value)
    {
        _settingPanel.SetActive(value);
    }

    public void SetGameoverPanel(bool value)
    {
        _gameoverPanel.SetActive(value);

    }




}
