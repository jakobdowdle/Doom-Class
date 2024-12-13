using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : WeaponBehaviour
{
    [SerializeField] private int ShotgunDamageMin, ShotgunDamageMax;
    public int Hit()
    {
       return Random.Range(ShotgunDamageMin, ShotgunDamageMax);
    }
}
