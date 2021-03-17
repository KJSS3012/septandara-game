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
        return Input.GetKeyDown(KeyCode.Space) || jump;
    }

    public void JumpButtonTrue()
    {
        jump = true;
    }

    public void JumpButtonFalse()
    {
        jump = false;
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
