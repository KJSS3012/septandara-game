using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{

    public MouseTouchLoadScene mtLS;
    public int sceneIndex;

    private void Start()
    {
        mtLS = GetComponentInChildren<MouseTouchLoadScene>();
    }

    public void Active()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        if (mtLS.player.isGround)
        {
            mtLS.fadeUI.SetActive(true);
            mtLS.animPlayer.SetBool("entry", true);
        }
    }
}
