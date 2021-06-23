using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeActive : MonoBehaviour
{
    public MouseTouchOpenDoor mtObj;
    public Activator[] activatorObjs;
    private int sceneIndex;

    public void DesactiveObjectFade()
    {
        mtObj.fadeUI.SetActive(false);
    }

    private void VerifyObjectCollider()
    {
        for (int i = 0; i<activatorObjs.Length; i++)
        {
            if (activatorObjs[i].mtObj.isCollider)
            {
                sceneIndex = activatorObjs[i].sceneIndex;
                break;
            }
        }
    }

    public void LoadNewScene()
    {
        VerifyObjectCollider();
        SceneManager.LoadScene(sceneIndex);
    }


}
