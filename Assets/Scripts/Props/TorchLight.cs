using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    public GameObject tourchLight;
    bool _tourch;

    private void Start()
    {
        tourchLight.transform.position = Camera.main.transform.position;
        tourchLight.transform.rotation = Camera.main.transform.rotation;
    }
    public void TourchToggle(bool inputTourch)
    {
        _tourch = (!_tourch == inputTourch) ? true : false;

        tourchLight.SetActive(_tourch);
    }
}
