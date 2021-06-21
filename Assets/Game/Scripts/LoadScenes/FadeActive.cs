using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeActive : MonoBehaviour
{
    public MouseTouchOpenDoor mtObj;

    public void DesactiveObjectFade()
    {
        mtObj.fadeUI.SetActive(false);
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene(mtObj.sceneIndex);
    }


}
