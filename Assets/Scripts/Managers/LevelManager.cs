using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _hudPanel;
    [SerializeField] private GameObject _gameoverPanel;

    [SerializeField] private GameObject _playerSection;
    [SerializeField] private GameObject _enemySection;
    [SerializeField] private GameObject _envSection;


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
        _hudPanel.SetActive(false);
        _settingPanel.SetActive(false);
        _enemySection.SetActive(false);
        _envSection.SetActive(false);
        _gameoverPanel.SetActive(value);
        ///_playerSection.SetActive(false);

    }




}
