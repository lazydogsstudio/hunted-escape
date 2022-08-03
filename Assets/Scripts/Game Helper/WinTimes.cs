using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTimes : MonoBehaviour
{
    [SerializeField]
    GameObject _WinTimes;
    [SerializeField]
    Text _winTimesText;

    int _winTimes;

    void Start()
    {
        _winTimes = GameManager.instance.GetWinTimes();
        _winTimesText.text = "Chapter Clear " + _winTimes.ToString() + " Times";

        if (_winTimes > 0)
        {
            _WinTimes.SetActive(true);
        }
        else
        {
            _WinTimes.SetActive(false);
        }

    }


}
