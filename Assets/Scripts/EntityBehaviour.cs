using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour

{
    [SerializeField] private int health;

    public void takeDamage(int dmg)
    { 
            health -= dmg;
        Debug.Log(health);
        if (health < 1)
        {
            health = 0;
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}
