using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{ 
    //[SerializeField] private GameObject Shotgun;
    [SerializeField] private GameObject ShotgunPrefab;
    private int selectedWeapon;
    

    public static WeaponManager Instance;
    // Start is called before the first frame update
    void Awake(){
        Instance = this;
        //Debug.Log("startgun");
    }


    public void Start() 
    { 
        Instance = this;
    }
    public void reset()
    {
        selectedWeapon = 0;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
                WeaponSelect();
            }
            else
            {
                selectedWeapon++;
                WeaponSelect();
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= transform.childCount - 1)
            {
                selectedWeapon = transform.childCount - 1;
                WeaponSelect();
            }
            else
            {
                selectedWeapon--;
                WeaponSelect();
            }
        }

            if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            WeaponSelect();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (GetComponentInChildren<GameObject>().CompareTag("Shotgun") == true) 
            {
                selectedWeapon = 1;
                WeaponSelect();
            }
        }
       

        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.getAmmo(selectedWeapon) > 0)
            {
                shoot();
                GameManager.Instance.useAmmo(selectedWeapon);
            }
        }
        
    }

    void shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        GetComponentInChildren<WeaponBehaviour>().CheckCollision(hit);
    }

    public void addWeapon(GameObject Weapon) 
    {
       if (Weapon.CompareTag("Shotgun") == true)
        {
            Instantiate(ShotgunPrefab, transform);
        }
    }
    public int getWeapon()
    {
        return selectedWeapon;
    }
    void WeaponSelect()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {

            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                i++;
                continue;
            }
            weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
