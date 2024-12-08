using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    [SerializeField] private int armorAmount;
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="player")
        {
            GetComponent<Collider>().enabled = false;
            GameManager.Instance.gainHealth(armorAmount);
            Destroy(gameObject);
        }
    }
}
