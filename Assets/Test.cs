using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Test : MonoBehaviour
{

    public AudioMixer mixer;
    public InputField myInputField;

    public UnityEvent onUp, onDown;

    public Text placeholder;
    public string username;

    public GameObject content;

    public GameObject prefabItem;

    GameObject _tempItem;
    GameObject _tempText;

    [Range(0, 10)]
    public float audioRasnge;

    private void Awake()
    {
        placeholder.text = "Atanu";



    }

    private void Start()
    {

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            onUp.Invoke();

        if (Input.GetMouseButtonDown(1))
            onDown.Invoke();
    }


    public void PrintEvent()
    {
        mixer.SetFloat("Master", audioRasnge);
        print("Right Clicked");
    }

    public void PrintEvent2()
    {
        mixer.SetFloat("Sound Fx", audioRasnge);
        print("Left Clicked");
    }


    void CreateItem(string name)
    {

        _tempItem = Instantiate(prefabItem, transform.position, Quaternion.identity);
        _tempText = _tempItem.transform.GetChild(0).gameObject;
        _tempText.GetComponent<Text>().text = name;
        _tempItem.transform.SetParent(content.transform, false);
    }


    public void SetNameChange(string value)
    {
        // username = value;
        // print("OnChange " + value);

        _tempItem = Instantiate(prefabItem, transform.position, Quaternion.identity);
        _tempText = _tempItem.transform.GetChild(0).gameObject;
        _tempText.GetComponent<Text>().text = value;


    }

    public void SetNameEnd(string value)
    {
        // username = value;
        // print("End " + value);
        _tempItem.transform.SetParent(content.transform, false);


    }

    // private void Update()
    // {
    //     print(username);
    // }
}
