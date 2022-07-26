using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public Text message;
    public Text intreactMessage;
    public GameObject dropButton;
    public GameObject interactButton;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        intreactMessage.text = "";
        message.text = "";
    }

    public void SetMessage(string text, int timer = 2)
    {
        message.text = text;
        Invoke("SetMessageEmpty", timer);
    }

    public void SetMessageEmpty()
    {
        message.text = "";
    }




    public void SetIntreactMessage(string text)
    {

        intreactMessage.text = text;
    }

    public void SetActiveDropButton(bool value)
    {

        dropButton.SetActive(value);
    }

    public void SetActiveIntractButton(bool value)
    {
        interactButton.SetActive(value);
    }
}


