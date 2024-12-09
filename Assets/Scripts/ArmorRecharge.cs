using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorRecharge : MonoBehaviour
{
    [SerializeField] private int armorAmount;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (GameManager.Instance.getArmor() < armorAmount)
            {
                GetComponent<Collider>().enabled = false;
                GameManager.Instance.setArmor(armorAmount);
                Destroy(gameObject);
            }
        }
    }
}
