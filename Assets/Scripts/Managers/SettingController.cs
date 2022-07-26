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


    private void Start()
    {
        _dropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetQulalityLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = _qualityLevels[value];
    }


    public void SetMusic()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(_musicSlider.value) * 20f);
    }

    public void SetSFX()
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(_soundFxSlider.value) * 20f);
    }


}
