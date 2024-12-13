using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private int weapon;
    private bool shotgun;

    public static WeaponManager Instance;
    // Start is called before the first frame update
    void Awake(){
        Instance = this;
        //Debug.Log("startgun");
    }

    public void reset()
    {
        shotgun = false;
        weapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weapon = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (shotgun)
            {
                weapon = 1;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.getAmmo(weapon) > 0)
            {
                shoot();
                GameManager.Instance.useAmmo(weapon);
            }
        }
    }

    void shoot()
    {
        Debug.Log("Bang");
    }

    public void addShotgun()
    {
        shotgun = true;
    }

    public int getWeapon()
    {
        return weapon;
    }
}
