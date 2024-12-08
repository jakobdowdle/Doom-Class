using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount;
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="player")
        {
            GetComponent<Collider>().enabled = false;
            GameManager.Instance.gainHealth(ammoAmount);
            Destroy(gameObject);
        }
    }
}
