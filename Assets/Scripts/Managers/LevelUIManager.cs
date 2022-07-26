using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{

    public static LevelUIManager instance;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _hudPanel;
    [SerializeField] private GameObject _gameoverPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _settingPanel.SetActive(false);
        AudioManager.instance.playBackGroundSound(true);
    }

    public void SetAllUIActive(bool value)
    {
        _hudPanel.SetActive(value);
        _settingPanel.SetActive(value);
        _gameoverPanel.SetActive(value);
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
