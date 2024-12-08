using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private int health;
    private int armor;
    private int ammo;
    // Start is called before the first frame update
    void Start()
    {
        health=100;
        armor=0;
        ammo= 0; //Do you start with ammo?
    }

    void updateUI(){
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

    public void gainArmor(int armorPoints){
        armor+=armorPoints;
        updateUI();        
    }

    public void gainHealth(int heal){
        health+=heal;
        updateUI();
    }

    public void gainAmmo(int ammoNum){
        ammo+=ammoNum;
        updateUI();
    }

    public void endGame(){
        //play death animation
    }
}
