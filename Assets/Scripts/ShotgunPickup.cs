using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        WeaponManager.Instance.addShotgun();
        Destroy(gameObject);
    }
}
