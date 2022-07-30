using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _menuPanel;

    private void Start()
    {
        _settingPanel.SetActive(false);
    }

    public void SetMenuPanel(bool value)
    {
        _menuPanel.SetActive(value);
    }

    public void SetSettingPanel(bool value)
    {
        _settingPanel.SetActive(value);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
