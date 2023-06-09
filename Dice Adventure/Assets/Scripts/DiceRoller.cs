using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    public Rigidbody diceRigidbody;
    public float force = 5f;
    private DiceFace[] diceFaces;
    public int mana = 0;
    public int totalMana = 0;
    public TextMeshProUGUI manaText;
    public HealthCounter healthCounter;

    //sounds
    public AudioSource water;
    public AudioSource fire;
    public AudioSource thunder;
    public AudioSource rock;
    public AudioSource magic;
    public AudioSource enemyAttack;


    private bool isRolling = false;

    void Start()
    {
        if (!diceRigidbody) diceRigidbody = GetComponent<Rigidbody>();
        diceFaces = GetComponentsInChildren<DiceFace>();
    }

public void RollDice()
{
    if (!isRolling)
    {
        isRolling = true;
        diceRigidbody.isKinematic = false;
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f)).normalized;
        diceRigidbody.AddForce(randomDirection * force, ForceMode.Impulse);

        // Add random torque for more spin
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        float torqueStrength = force * 10f;
        diceRigidbody.AddTorque(randomTorque * torqueStrength, ForceMode.Impulse);

        StartCoroutine(WaitForDiceToStop());
    }
}


private IEnumerator WaitForDiceToStop()
{
    yield return new WaitForSeconds(2f);
    while (diceRigidbody.velocity.magnitude > 0.1f || diceRigidbody.angularVelocity.magnitude > 0.1f)
    {
        yield return null;
    }

    // Wait for a small delay after the dice stops moving
    yield return new WaitForSeconds(0.5f);

        //enemy attack sound
        enemyAttack.Play();
    // Get dice roll result here
    int result = GetDiceRollResult();
    mana = result;
    Debug.Log("Dice roll result: " + result);
    this.ManaMethod();
    healthCounter.loseHealth();
    diceRigidbody.isKinematic = true;
    isRolling = false;
}


    private int GetDiceRollResult()
    {
        foreach (DiceFace face in diceFaces)
        {
            if (face.IsTouchingGround())
            {
                return face.faceValue;
            }
        }

        // Default value in case no face is detected touching the ground
        return 1;
    }


    public void ManaMethod()
    {
        totalMana += mana;
        manaText.text = "Mana: " + totalMana;
    }

    public void useTorrent()
    {
        if(totalMana > 0) {
            water.Play();
            totalMana -= 1;
            manaText.text = "Mana: " + totalMana;
            healthCounter.damage(1);
        }
        
    }

    public void useFireball()
    {
        if(totalMana >=2) {
            fire.Play();
            totalMana -= 2;
        manaText.text = "Mana: " + totalMana;
        healthCounter.damage(3);
        }
        
    }

    public void useShockwave()
    {
        if(totalMana >=3) {
            thunder.Play();
            totalMana -= 3;
        manaText.text = "Mana: " + totalMana;
        healthCounter.damage(5);  
        }
          
    }

    public void useBoulderush()
    {
        if(totalMana >=4) {
            rock.Play();
            totalMana -= 4;
        manaText.text = "Mana: " + totalMana;
        healthCounter.damage(7);
        }
        
    }

    public void useSmite() 
    {
        if(totalMana >= 5) {
            magic.Play();
            totalMana -= 5;
        manaText.text = "Mana: " + totalMana;
            healthCounter.heal();
            healthCounter.damage(2);
        }   
    }


}
