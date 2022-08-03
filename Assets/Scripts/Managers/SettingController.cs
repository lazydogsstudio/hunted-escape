using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingController : MonoBehaviour
{
    [SerializeField]
    private RenderPipelineAsset[] _qualityLevels;

    [SerializeField]
    private Dropdown _dropdown;

    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider _musicSlider;
    [SerializeField]
    private Slider _soundFxSlider;

    private float _x;

    private void Start()
    {
        _dropdown.value = QualitySettings.GetQualityLevel();
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        _soundFxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SetQulalityLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = _qualityLevels[value];
    }

    public void SetMusic()
    {
        audioMixer.SetFloat("MusicVolume", _musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }

    public void SetSFX()
    {
        audioMixer.SetFloat("SFXVolume", _soundFxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", _soundFxSlider.value);
    }


}
