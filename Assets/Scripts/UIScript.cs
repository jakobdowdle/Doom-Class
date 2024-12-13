using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject ammoUI;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject armorUI;

    public void setUI(int health, int armor, int[] ammo){
        updateHealth(health.ToString());
    }

    void updateHealth(string h){
        if(h.Length<2){
        healthUI.GetComponent<TextMeshProUGIU>().text ="<sprite name=\""+h[0]+"\"><sprite name=\""+h[1]+"\"><sprite name=\""+h[2]+"\"><sprite name=\"%\">";
        } else if (h.Length==2){
        healthUI.GetComponent<TextMesh>().text ="<sprite name=\""+h[0]+"\"><sprite name=\""+h[1]+"\"><sprite name=\"%\">";
        } else if (h.Length==1){
        healthUI.GetComponent<TextMesh>().text ="<sprite name=\""+h[0]+"\"><sprite name=\"%\">";
        } else {
        healthUI.GetComponent<TextMesh>().text ="<sprite name=\"0\"><sprite name=\"%\">";
        }
    }
}
