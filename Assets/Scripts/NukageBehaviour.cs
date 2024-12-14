using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukageBehaviour : MonoBehaviour
{
    [SerializeField] private int nukageDamage = 5;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float damageRate = 2f;
    private void OnTriggerStay(Collider other)
    {
        if (timer >= damageRate)
        {
            GameManager.Instance.takeDamage(nukageDamage);
            timer = 0f;
        }
        else
            timer += Time.deltaTime;
            
        

    }
  
}
