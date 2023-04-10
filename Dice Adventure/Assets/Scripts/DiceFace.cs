using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFace : MonoBehaviour
{
    public int faceValue;

    private bool isTouchingGround = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }

    public bool IsTouchingGround()
    {
        return isTouchingGround;
    }
}
