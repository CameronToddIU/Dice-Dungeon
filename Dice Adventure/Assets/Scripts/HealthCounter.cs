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
    int enemyHealth = 10;
    bool enemyHealthChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        healthChanged = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if health changes (using boolean variable to determine) then change the text number.
        if (healthChanged)  
        {
            //set text to value health 
            healthText.text = health.ToString();
            //set bool to false again so we can only change it when the value changes.
            healthChanged = false;
        }
        if (enemyHealthChanged)  
        {
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

}
