using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float yRotation = 0f;

    [Header("Door Details")]
    public int doorId;
    public string hint;

    [Header("Door Properties")]
    public float openRotation;
    public float closeRotation;
    public bool locked;
    public bool open;

    void Update()
    {
        DoorState();
    }

    public void DoorState()
    {
        if (open && !locked)
            yRotation -= 1.5f;
        else
            yRotation += 1.5f;

        yRotation = Mathf.Clamp(yRotation, openRotation, closeRotation);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    public void DoorOpen(bool openDoor)
    {
        open = (!open == openDoor) ? true : false;
    }

    public void DoorUnlock()
    {
        locked = false;
    }
}
