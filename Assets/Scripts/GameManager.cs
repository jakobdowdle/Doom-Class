using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private int health;
    private int armor;
    private int ammo;
    
    public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        health=100;
        armor=0;
        ammo= 0; //Do you start with ammo?
        Instance=this;
    }

    void updateUI(){
        Debug.Log(health+" "+armor+" "+ammo);
        //UI.getCompontent<UIBehaviour>().SetUI(health, armor, ammo);
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
        if(health>100)
        {
            health=100;
        }
        updateUI();
    }

    public void setHealth(int heal)
    {
        health = 100;
        updateUI();
    }

    public void gainAmmo(int ammoNum){
        ammo+=ammoNum;
        updateUI();
    }

    public void endGame(){
        //play death animation
    }

    public int getArmor()
    {
        return armor;
    }
}
