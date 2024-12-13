using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject ammoUI;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject armorUI;
    [SerializeField] private GameObject[] weaponUI;

    private void Start()
    {
        switchToPistol();
    }

    public void setUI(int health, int armor, int[] ammo){
        updateHealth(health.ToString());
        updateArmor(armor.ToString());
        updateAmmo(ammo[WeaponManager.Instance.getWeapon()].ToString());
    }

    void updateHealth(string h){
        //Debug.Log(h.Length);
        if(h.Length>2){
        healthUI.GetComponent<TextMeshProUGUI>().text ="<sprite name=\""+h[0]+"\"><sprite name=\""+h[1]+"\"><sprite name=\""+h[2]+"\"><sprite name=\"%\">";
        } else if (h.Length==2){
        healthUI.GetComponent<TextMeshProUGUI>().text ="<sprite name=\""+h[0]+"\"><sprite name=\""+h[1]+"\"><sprite name=\"%\">";
        } else if (h.Length==1){
        healthUI.GetComponent<TextMeshProUGUI>().text ="<sprite name=\""+h[0]+"\"><sprite name=\"%\">";
        } else {
        healthUI.GetComponent<TextMeshProUGUI>().text ="<sprite name=\"0\"><sprite name=\"%\">";
        }
    }

    void updateArmor(string a)
    {
        //Debug.Log(a.Length);
        if (a.Length > 2)
        {
            armorUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"" + a[0] + "\"><sprite name=\"" + a[1] + "\"><sprite name=\"" + a[2] + "\"><sprite name=\"%\">";
        }
        else if (a.Length == 2)
        {
            armorUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"" + a[0] + "\"><sprite name=\"" + a[1] + "\"><sprite name=\"%\">";
        }
        else if (a.Length == 1)
        {
            armorUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"" + a[0] + "\"><sprite name=\"%\">";
        }
        else
        {
            armorUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"0\"><sprite name=\"%\">";
        }
    }

    void updateAmmo(string amo)
    {
        //Debug.Log(amo.Length);
        if (amo.Length > 2)
        {
            ammoUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"" + amo[0] + "\"><sprite name=\"" + amo[1] + "\">";
        }
        else if (amo.Length == 2)
        {
            ammoUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"" + amo[0] + "\"><sprite name=\"" + amo[1] + "\">";
        }
        else if (amo.Length == 1)
        {
            ammoUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"" + amo[0] + "\">";
        }
        else
        {
            ammoUI.GetComponent<TextMeshProUGUI>().text = "<sprite name=\"0\">";
        }
    }

    public void updateWeapon(int weapon)
    {
        switch (weapon)
        {
            case 0:
                switchToPistol();
                break;
            case 1:
                switchToShotgun();
                break;
            default:
                switchToPistol();
                break;
        }
    }

    public void switchToPistol()
    {
        foreach (GameObject w in weaponUI)
        {
            w.SetActive(false);
        }
        weaponUI[0].SetActive(true);
    }

    public void switchToShotgun()
    {
        foreach (GameObject w in weaponUI)
        {
            w.SetActive(false);
        }
        weaponUI[1].SetActive(true);
    }
}
