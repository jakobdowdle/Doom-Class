using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class WeaponBehaviour : MonoBehaviour
{
    public GameObject Entity;
    
    [SerializeField] private int ShotgunDamageMin, ShotgunDamageMax;
    [SerializeField] private int PistolDamage;

    [SerializeField] private AudioSource PistolShot;
    [SerializeField] private AudioSource ShotgunShot;

    private void Awake() {
        if (PistolShot == null) {
            PistolShot = GetComponentInChildren<AudioSource>();
            if (PistolShot == null) {
                Debug.LogError("No AudioSource found.");
            }
        }
        if (ShotgunShot == null) {
            ShotgunShot = GetComponentInChildren<AudioSource>();
            if (ShotgunShot == null) {
                Debug.LogError("No AudioSource found.");
            }
        }
    }

    public void CheckCollision(RaycastHit hit)
    { 
        if(WeaponManager.Instance.getWeapon() == 0 && PistolShot != null) {
            PistolShot.Play();
        }
        if (WeaponManager.Instance.getWeapon() == 1 && ShotgunShot != null) {
            ShotgunShot.Play();
        }
        if (hit.transform.CompareTag("Enemy") || hit.transform.CompareTag("Player"))
        {
            Entity = hit.collider.gameObject;
                Entity.GetComponent<EntityBehaviour>().takeDamage(Hit());
        }
    }
    
    public int Hit()
    {
        switch (WeaponManager.Instance.getWeapon())
        {
            case 0:
                return PistolDamage;
            case 1:
                //I still can't believe this is how OG DOOM does it
                return Random.Range(ShotgunDamageMin, ShotgunDamageMax) * 3;
        }
        return 0;
    }

}
