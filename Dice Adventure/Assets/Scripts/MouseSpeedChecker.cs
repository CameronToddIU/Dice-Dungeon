using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpeedChecker : MonoBehaviour
{
    public float mouseSpeedThreshold = 200f;
    public DiceRoller diceRoller;
    private Vector3 lastMousePosition;
    private float mouseSpeed;

    void Update()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        mouseSpeed = (currentMousePosition - lastMousePosition).magnitude / Time.deltaTime;
        lastMousePosition = currentMousePosition;

        if (mouseSpeed >= mouseSpeedThreshold)
        {
            if (diceRoller != null)
            {
                diceRoller.RollDice();
            }
            else
            {
                Debug.LogError("DiceRoller is not assigned in MouseSpeedChecker script.");
            }
        }
    }
}
