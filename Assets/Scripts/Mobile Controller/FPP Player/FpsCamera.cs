using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    public TouchArea fixedtouch;
    [Range(1, 10)]
    public float mouseSentivity;
    public Transform playerBody; //Get Player Body
    float xRotation = 0f;
    Vector2 lookInput = Vector2.zero;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //Set only lookInput value
        lookInput = fixedtouch.touchDist;

        float mouseX = lookInput.x * mouseSentivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSentivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
