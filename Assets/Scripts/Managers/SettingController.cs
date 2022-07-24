using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField]
    private RenderPipelineAsset[] _qualityLevels;

    [SerializeField]
    private Dropdown _dropdown;


    private void Start()
    {
        _dropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetQulalityLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = _qualityLevels[value];
    }


}
