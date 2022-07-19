using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    public LayerMask layerMask;

    public float throwSpeed = 5f;
    public Text objNameText;

    public GameObject dropBtn;
    public GameObject picUpBtn;

    public GameObject hand;

    private bool _allReadyGrabed;

    RaycastHit hit;
    void Update()
    {


        if (_allReadyGrabed)
        {
            dropBtn.SetActive(true);
        }
        else
        {
            dropBtn.SetActive(false);
        }




        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 10f, layerMask))
        {
            objNameText.text = hit.transform.name.ToString();
            picUpBtn.SetActive(true);
        }
        else
        {
            objNameText.text = "";
            picUpBtn.SetActive(false);
        }
    }


    public void onGrab()
    {

        if (hit.transform.gameObject.CompareTag("Door"))
        {
            OpenDoor();
        }


        else
        {

            if (_allReadyGrabed)
            {
                onDrop();
            }

            if (!_allReadyGrabed)
            {

                hit.rigidbody.GetComponent<Rigidbody>().useGravity = false;
                hit.rigidbody.transform.SetParent(hand.transform);
                hit.rigidbody.isKinematic = true;

                hit.rigidbody.transform.localRotation = Camera.main.transform.rotation;

                hit.rigidbody.transform.position = hand.transform.position;

                _allReadyGrabed = true;
            }
        }



    }

    public void onDrop()
    {

        Rigidbody rb = hand.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        if (rb.CompareTag("Place"))
            rb.velocity = transform.forward;
        else
            rb.velocity = transform.forward * throwSpeed;
        hand.transform.GetChild(0).parent = null;

        _allReadyGrabed = false;
    }







    void OpenDoor()
    {
        Door door = hit.transform.gameObject.GetComponent<Door>();

        if (!door.locked) // If Door is InLocked
        {
            door.DoorOpen(true); // Door Toggle
        }

        if (door.locked && hand.transform.GetChild(0).CompareTag("Key")) // If Door is Locked
        {
            print("Error Key");
            Key key = hand.transform.GetChild(0).gameObject.GetComponent<Key>();

            if (key.keyId == door.doorId)
            {
                door.DoorUnlock();
                door.DoorOpen(true);
            }

        }
    }

}

