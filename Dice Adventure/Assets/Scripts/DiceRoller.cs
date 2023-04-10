using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public Rigidbody diceRigidbody;
    public float force = 5f;
    private DiceFace[] diceFaces;

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

    // Get dice roll result here
    int result = GetDiceRollResult();
    Debug.Log("Dice roll result: " + result);

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


}
