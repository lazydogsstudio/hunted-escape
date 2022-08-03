using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private GameObject _gun;

    public void IncrementGunAmmo(int value)
    {
        Gun g = _gun.GetComponent<Gun>();
        g.IncrementAmmo(value);
        g.updateAmmo();

        Destroy(gameObject);
    }
}
