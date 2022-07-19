using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    public GameObject light;
    bool _tourch;

    private void Start()
    {
        light.transform.position = Camera.main.transform.position;
        light.transform.rotation = Camera.main.transform.rotation;
    }
    public void TourchToggle(bool inputTourch)
    {
        _tourch = (!_tourch == inputTourch) ? true : false;

        light.SetActive(_tourch);
    }
}
