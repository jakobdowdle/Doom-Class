using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthAmount;
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="player")
        {
            GetComponent<Collider>().enabled = false;
            GameManager.Instance.gainHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
