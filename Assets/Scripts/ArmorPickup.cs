using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    [SerializeField] private int armorAmount;
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (GameManager.Instance.getArmor() <= 200)
            {
                GetComponent<Collider>().enabled = false;
                GameManager.Instance.gainArmor(armorAmount);
                Destroy(gameObject);
            }
        }
    }
}
