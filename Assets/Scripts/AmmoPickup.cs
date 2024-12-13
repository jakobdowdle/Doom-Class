using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int weaponType;
    [SerializeField] private int ammoAmount;
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            GetComponent<Collider>().enabled = false;
            GameManager.Instance.gainAmmo(weaponType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
