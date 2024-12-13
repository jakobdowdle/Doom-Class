using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
            WeaponManager.Instance.addWeapon(gameObject);
            Destroy(gameObject);
        }
    }
}
