using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public Rigidbody diceRigidbody;
    public float force = 5f;

    private bool isRolling = false;

    void Start()
    {
        if (!diceRigidbody) diceRigidbody = GetComponent<Rigidbody>();
    }

    public void RollDice()
    {
        if (!isRolling)
        {
            isRolling = true;
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f)).normalized;
            diceRigidbody.AddForce(randomDirection * force, ForceMode.Impulse);
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

        // Get dice roll result here
        int result = GetDiceRollResult();
        Debug.Log("Dice roll result: " + result);

        isRolling = false;
    }

    private int GetDiceRollResult()
    {
        int result = 1;
        float maxDot = -1;

        for (int i = 1; i <= 6; i++)
        {
            Vector3 faceUpDirection = GetFaceUpDirection(i);
            float dot = Vector3.Dot(transform.up, faceUpDirection);
            if (dot > maxDot)
            {
                maxDot = dot;
                result = i;
            }
        }

        return result;
    }

    private Vector3 GetFaceUpDirection(int face)
    {
        switch (face)
        {
            case 1: return Vector3.up;
            case 2: return Vector3.right;
            case 3: return Vector3.forward;
            case 4: return Vector3.back;
            case 5: return Vector3.left;
            case 6: return Vector3.down;
            default: return Vector3.zero;
        }
    }
}
