using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour {
    [SerializeField] private int health;
    [SerializeField] private AudioSource EnemyPain;
    [SerializeField] private AudioSource EnemyShoot;

    private void Awake() {
        if (EnemyPain == null) {
            //EnemyPain = GetComponentInChildren<AudioSource>();
            if (EnemyPain == null) {
                Debug.LogError("No AudioSource found.");
            }
        }
        if (EnemyShoot == null) {
            EnemyShoot = GetComponentInChildren<AudioSource>();
            if (EnemyShoot == null) {
                Debug.LogError("No AudioSource found.");
            }
        }
    }

    public void takeDamage(int dmg) {
        health -= dmg;
        Debug.Log(health);

        if (EnemyPain != null) {
            EnemyPain.Play();
        }

        if (health < 1) {
            health = 0;
            Die();
        }
    }

    void Die() {
        gameObject.SetActive(false);
    }
}
