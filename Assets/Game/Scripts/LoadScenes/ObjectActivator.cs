using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectActivator : MonoBehaviour
{

    public MouseTouchLoadScene mtLS;
    public int sceneIndex;

    public void Active()
    {
        mtLS = GetComponentInChildren<MouseTouchLoadScene>();
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        if (mtLS.player.isGround)
        {
            mtLS.fadeUI.SetActive(true);
            mtLS.animPlayer.SetBool("entry", true);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
