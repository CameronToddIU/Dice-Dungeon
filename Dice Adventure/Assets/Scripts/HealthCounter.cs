using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI enemyHealthText;
    bool healthChanged = false;
    int health = 20;
    float maxHealth = 20;
    int enemyHealth = 15;
    float maxEnemyHealth = 15;
    bool enemyHealthChanged = false;
    bool enemyKilled = false;
    public Image hpBar;
    public Image EHP;

    public int enemyHealthIncrease = 5;

    public int spriteIndex = 0;
    public Sprite[] enemySprites;
    [SerializeField]
    public GameObject enemyGameObject;
    private RawImage spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        healthChanged = true;
        enemyHealthChanged = true;
        // spriteRenderer = GetComponent<SpriteRenderer>();

        // spriteRenderer = enemyGameObject.GetComponent<Image>();
        if (enemyGameObject != null)
        {
            spriteRenderer = enemyGameObject.GetComponent<RawImage>();
            if (spriteRenderer == null)
            {
                Debug.LogError("Failed to obtain the RawImage component.");
            }
        }
        else
        {
            Debug.LogError("Enemy GameObject is not assigned");
        }
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
            hpBar.fillAmount = health/maxHealth;
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
            EHP.fillAmount = enemyHealth/maxEnemyHealth;
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
        if(enemyHealth <= 0)
        {
            Debug.Log("EnemyDied");
            enemyHealth = 15 + enemyHealthIncrease;
            maxEnemyHealth = 15 + enemyHealthIncrease;
            enemyHealthIncrease = enemyHealthIncrease + 5;
            spriteIndex++;
            SwapSprite(spriteIndex);
        }
        enemyHealthChanged = true;
    }

    public void heal(){
        UnityEngine.Debug.Log(enemyHealth);
        if(enemyHealth <= 2){
            health = health + 5;
            if(health >= 20){
                health = 20;
            }
            healthChanged = true;
        }
    }

        public void SwapSprite(int index)
    {
        if (spriteRenderer != null && enemySprites != null && index >= 0 && index < enemySprites.Length)
        {
            spriteRenderer.texture = enemySprites[index].texture;
        }
    }

}
