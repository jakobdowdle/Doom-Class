using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public GameObject Entity;
 
    public void Fire(RaycastHit hit)
    {
        
        GetComponent<AudioSource>().Play();
        if (hit.transform.tag == "Enemy" || hit.transform.tag == "Player")
        {
          
            //Entity.Hit();
        }
    }
    public virtual int Hit(int damage)
    {
        return damage;
    }

}
