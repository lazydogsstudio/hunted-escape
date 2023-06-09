
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public LayerMask interactLayerMask;
    public float throwSpeed = 5f;
    public GameObject playerHand;

    bool _allReadyGrabed;
    RaycastHit hit;

    void Update()
    {
        //Drop Button Manager
        if (_allReadyGrabed) // is Object in Player Hand  
        {
            HUDManager.instance.SetActiveDropButton(true); //Show Drop Button
        }
        else
        {
            HUDManager.instance.SetActiveDropButton(false); //Hide Drop Button
        }


        // Interact Button Manager
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 10f, interactLayerMask))
        {
            HUDManager.instance.SetIntreactMessage(hit.transform.name.ToString());
            HUDManager.instance.SetActiveIntractButton(true);
        }
        else
        {
            HUDManager.instance.SetIntreactMessage("");
            HUDManager.instance.SetActiveIntractButton(false);
        }
    }


    public void onInteract()
    {
        // Interact With Door
        if (hit.transform.gameObject.CompareTag("Door"))
        {
            openDoor();
        }

        // Interact With Ammo
        else if (hit.transform.gameObject.CompareTag("Ammo"))
        {
            incrementAmmo();
        }

        else
        {
            // If no object in player hand then pickup the object
            if (!_allReadyGrabed)
            {
                onPickup();
            }
            // If any pickupable object in player hand then drop the object
            else
            {
                onDrop();
                onPickup();
            }
        }
    }


    void incrementAmmo()
    {
        AudioManager.instance.PlayPickupSound();
        hit.collider.GetComponent<Ammo>().IncrementGunAmmo(10);
    }


    // Pickup Pickupable Object in Player Hand
    void onPickup()
    {
        hit.rigidbody.GetComponent<Rigidbody>().useGravity = false;


        hit.rigidbody.transform.SetParent(playerHand.transform);

        if (hit.rigidbody.CompareTag("Gun"))
        {
            HUDManager.instance.SetActiveGunUI(true);
            hit.rigidbody.transform.localRotation = Quaternion.Euler(80f, 0f, 0f);
        }


        else
            hit.rigidbody.transform.localRotation = Quaternion.identity;

        hit.rigidbody.isKinematic = true;


        hit.rigidbody.transform.position = playerHand.transform.position;

        AudioManager.instance.PlayPickupSound();

        _allReadyGrabed = true;
    }


    // Drop/Throw Pickupable Object 
    public void onDrop()
    {
        Rigidbody rb = playerHand.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        if (rb.CompareTag("Gun")) /// Gun Button false;
            HUDManager.instance.SetActiveGunUI(false);

        if (rb.CompareTag("Place"))
            rb.velocity = transform.forward;
        else
            rb.velocity = transform.forward * throwSpeed;

        playerHand.transform.GetChild(0).parent = null;  // Player Hand Clear

        _allReadyGrabed = false; // No Object on Player Hand 
    }


    void openDoor()
    {
        Door door = hit.transform.gameObject.GetComponent<Door>();


        if (door.locked &&
       playerHand.transform.childCount > 0 &&
       playerHand.transform.GetChild(0).CompareTag("Key")) // If Door is Locked
        {
            Key key = playerHand.transform.GetChild(0).gameObject.GetComponent<Key>(); // Get Key Data


            if (key.keyId == door.doorId) //If Key ID and Door ID is Same 
            {
                door.DoorUnlock(); // Unlock The Door
                AudioManager.instance.PlayDoorOpenSound();

                // door.DoorOpen(true); // Open The Door


                GameObject keyO = playerHand.transform.GetChild(0).gameObject;
                onDrop();
                Destroy(keyO);

            }
            else
            {
                AudioManager.instance.PlayDoorLockedSound();
                HUDManager.instance.SetMessage(door.hint, timer: 4); //Show message door is locked
            }
        }

        else
        {

            if (!door.locked) // If Door is not Locked
            {
                AudioManager.instance.PlayDoorOpenSound();
                door.DoorOpen(true); // Door Toggle
            }
            else
            {
                AudioManager.instance.PlayDoorLockedSound();
                HUDManager.instance.SetMessage(door.hint, timer: 4); //Show message door is locked
            }
        }


    }

}

