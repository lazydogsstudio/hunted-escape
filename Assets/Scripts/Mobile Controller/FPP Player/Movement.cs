using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movement : MonoBehaviour
{
    public GameObject analog;
    public CharacterController characterController;

    private Camera cam;

    public Transform viewPoint;

    [Range(0f, 6f)]
    public float speed = 4f;
    public float gravity = -9.81f;
    public float gravityMod = 2.5f;
    public float jumpHeight = 3f;

    public LayerMask layerMask; //Use for check player is Grounded
    public Transform groundCheck; //This is ground layer

    Vector2 moveInput = Vector2.zero;
    Vector3 velocity;
    Vector3 _moveDiraction, _movement;

    bool _grounded;
    bool _crouched;

    bool _isWalking;


    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        PlayerMove();
    }

    private void LateUpdate()
    {
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }

    public void PlayerCrouch(bool inputCrouch)
    {
        _crouched = (!_crouched == inputCrouch) ? true : false;
        characterController.height = _crouched ? 1f : 2f;
    }

    void PlayerMove() //Player Move
    {
        // Player Move Input Value GET
        _moveDiraction = new Vector3(analog.transform.localPosition.x, 0f, analog.transform.localPosition.y);
        float yVelocity = _movement.y;
        _movement = ((transform.forward * _moveDiraction.z) + (transform.right * _moveDiraction.x)).normalized;
        _movement.y = yVelocity;


        if (characterController.isGrounded)
            _movement.y = 0f;
        _movement.y += Physics.gravity.y * Time.deltaTime * gravityMod;



        // if (_moveDiraction.x != 0f)
        // {
        //     _isWalking = true;
        // }
        // else
        // {
        //     _isWalking = false;
        // }


        // if (_isWalking)
        // {
        //     if (!AudioManager.instance.playerFootStepSound.isPlaying)
        //     {
        //         AudioManager.instance.playerFootStepSound.Play();
        //     }
        // }
        // else
        // {
        //     AudioManager.instance.playerFootStepSound.Stop();
        // }





        // _isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, .25f, groundLayerMask);
        // Jump();

        characterController.Move(_movement * Time.deltaTime * speed);





    }

    public void SetPlayerSpeed(float value)
    {
        speed = value;
    }







}