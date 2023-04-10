using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI enemyHealthText;
    bool healthChanged = false;
    int health = 10;
    int enemyHealth = 25;
    bool enemyHealthChanged = false;
    bool enemyKilled = false;
    // Start is called before the first frame update
    void Start()
    {
        healthChanged = true;
        enemyHealthChanged = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if health changes (using boolean variable to determine) then change the text number.
        if (healthChanged)  
        {
            if(health <= 0){
                health = 0;
                UnityEngine.Debug.Log("player died");
                //death method
            }
            //set text to value health 
            healthText.text = health.ToString();
            //set bool to false again so we can only change it when the value changes.
            healthChanged = false;
        }
        if (enemyHealthChanged)  
        {
            if(enemyHealth <= 0){
                enemyHealth = 0;
                //death method
            }
            //set text to value health 
            enemyHealthText.text = enemyHealth.ToString();
            //set bool to false again so we can only change it when the value changes.
            enemyHealthChanged = false;
        }
    }
    public void loseHealth()
    {
        health = health - 1;
        healthChanged = true;
    }
    public void damage(int d)
    {
        enemyHealth = enemyHealth - d;
        enemyHealthChanged = true;
    }

    public void heal(){
        if(enemyHealth <= 0){
            health = health + 5;
            if(health >= 10){
                health = 10;
            }
            healthChanged = true;
        }
    }

}
