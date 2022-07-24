using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movement : MonoBehaviour
{
    public GameObject analog;
    public CharacterController characterController;

    [Range(0, 10)]
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public LayerMask layerMask; //Use for check player is Grounded
    public Transform groundCheck; //This is ground layer

    Vector2 moveInput = Vector2.zero;
    Vector3 velocity;

    bool _grounded;
    bool _crouched;


    void Update()
    {
        PlayerGravity();
        PlayerMove();
    }


    public void PlayerCrouch(bool inputCrouch)
    {
        _crouched = (!_crouched == inputCrouch) ? true : false;
        characterController.height = _crouched ? 1f : 2f;
    }

    void PlayerMove() //Player Move
    {
        // Player Move Input Value GET
        float x = analog.transform.localPosition.x;
        float z = analog.transform.localPosition.y;

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed / 100 * Time.deltaTime);
    }

    void PlayerGravity() //Player Gravity
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void SetPlayerSpeed(float value)
    {
        speed = value;
    }







}