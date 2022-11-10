using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private bool moveRight, moveLeft;
    private bool jump;

    public Vector3 GetMovimentInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput == 0f)
        {
            if(moveRight)
            {
                horizontalInput = 1f;
            }
            else if(moveLeft)
            {
                horizontalInput = -1f;
            }
        }

        return new Vector3(horizontalInput, 0f, 0f);
    }
    
    public bool IsJumpButtonInterface()
    {
        if (jump) 
        {
            jump = false;
            return !jump;
        }
        return false;
    }

    public bool IsJumpKeyboard()
    {
        bool inputJump = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        return inputJump;
    }

    public void IsJumpTrue()
    {
        jump = true;
    }

    public void MoveRightTrue()
    {
        moveRight = true;
    }

    public void MoveRightFalse()
    {
        moveRight = false;
    }

    public void MoveLeftTrue()
    {
        moveLeft = true;
    }

    public void MoveLeftFalse()
    {
        moveLeft = false;
    }

    public bool PressedC()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            return true;
        }
        return false;
    }
}
