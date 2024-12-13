using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject spawn;

    private int health;
    private int armor;
    private int[] ammo;
    
    public static GameManager Instance;
    // Start is called before the first frame update

    void Start()
    {
        Instance=this;
        StartGame();
        //Debug.Log("start");
    }

    void StartGame()
    {
        PlayerController.Instance.setLocation(spawn.transform.position);
        WeaponManager.Instance.reset();
        health=100;
        armor=0;
        ammo= new int[] {50, 0}; //Do you start with ammo?
        updateUI();
    }

    void updateUI(){
        //Debug.Log(health+" "+armor+" [" + ammo[0] + "," + ammo[1]+"]");
        UI.GetComponent<UIScript>().setUI(health, armor, ammo);
    }

    public void takeDamage(int dmg){
        if (armor>0){
            armor-= 5;
            health-= dmg/3;
            if(armor<0){
                armor=0;
            }
        }else{
            health-=dmg;
        }
        if(health<1){
            health=0;
            endGame();
        }
        updateUI();
    }

    public void setArmor(int armorPoints){
        armor=armorPoints;
        updateUI();        
    }

    public void gainArmor(int armorPoints)
    {
        armor += armorPoints;
        if (armor > 200)
        {
            armor = 200;
        }
        updateUI();
    }

    public void gainHealth(int heal){
        health+=heal;
        updateUI();
    }

    public void setHealth()
    {
        health = 100;
        updateUI();
    }

    public void gainAmmo(int weapon, int ammoNum){
        ammo[weapon]+=ammoNum;
        updateUI();
    }

    public void useAmmo(int weapon)
    {
        ammo[weapon]--;
        updateUI();
    }

    public void endGame(){
        //play death animation
        StartGame();
    }

    public int getArmor()
    {
        return armor;
    }

    public int getHealth()
    {
        return health;
    }

    public int getAmmo(int weapon)
    {
        return ammo[weapon];
    }

    public void setWeapon(int weapon)
    {
        UI.GetComponent<UIScript>().updateWeapon(weapon);
        updateUI();
    }
}
