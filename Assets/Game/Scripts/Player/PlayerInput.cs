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
    
    public bool IsJump()
    {
        bool inputJump = Input.GetKeyDown(KeyCode.Space);

        if (jump) 
        {
            jump = false;
            return !jump;
        }
        else
        {
            return inputJump;
        }
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
}
