using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (GameManager.Instance.getHealth() < 100)
            {
                GetComponent<Collider>().enabled = false;
                GameManager.Instance.setHealth();
                Destroy(gameObject);
            }
        }
    }
}
