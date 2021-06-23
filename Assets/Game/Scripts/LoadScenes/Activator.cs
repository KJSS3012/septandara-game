using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public MouseTouchOpenDoor mtObj;
    public int sceneIndex;

    public void StartTransition()
    {
        if (mtObj.player.isGround)
        {
            mtObj.player.spritePlayer.flipX = false;
            mtObj.fadeUI.SetActive(true);
            mtObj.animFade.SetTrigger("out");
            mtObj.animPlayer.SetBool("entry", true);
        }
    }

}
