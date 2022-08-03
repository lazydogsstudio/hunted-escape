using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private int _ammo = 0;
    private float _shotCounter;
    public float timeBetweenShorts = 0.1f;

    void Start()
    {
        HUDManager.instance.SetAmmoValue(_ammo);
    }

    public void IncrementAmmo(int value)
    {
        _ammo += value;
    }

    public void updateAmmo()
    {

        HUDManager.instance.SetAmmoValue(_ammo);
    }


    public void shoot()
    {
        if (_ammo > 0)
        {

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {

                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<Enemy>().takeDamage();
                }
            }

            AudioManager.instance.PlayFireSound();
            _ammo--;
            HUDManager.instance.SetAmmoValue(_ammo);
        }

    }
}
