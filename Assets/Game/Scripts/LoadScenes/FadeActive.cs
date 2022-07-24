using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeActive : MonoBehaviour
{
    public MouseTouchLoadScene mtLS;
    public ObjectActivator[] objsActives;
    private int sceneIndex;

    public void DesactiveObjectFade()
    {
        this.gameObject.SetActive(false);
    }

    private void VerifyObjectCollider()
    {
        for (int i = 0; i< objsActives.Length; i++)
        {
            if (objsActives[i].mtLS.isCollider)
            {
                sceneIndex = objsActives[i].sceneIndex;
                break;
            }
        }
    }

    private void Awake()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        VerifyObjectCollider();
        SceneManager.LoadScene(sceneIndex);
    }

}
