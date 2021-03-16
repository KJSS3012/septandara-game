using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private bool moveRight, moveLeft;
    
    public Vector3 GetMovimentInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        return new Vector3(horizontalInput, 0f, 0f);
    }
    
    public bool IsJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    

}
