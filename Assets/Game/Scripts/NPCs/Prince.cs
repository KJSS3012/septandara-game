using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince : MonoBehaviour
{
    private Animator animPrince;
    public GameObject fadeUI;
    public bool isAttack;
    public GameObject target;
    public VisibilityControls vsControls;
    public bool isDesactiveControls; //For timeline

    private void Start()
    {
        animPrince = GetComponent<Animator>();
        if (!isDesactiveControls)
        {
            vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
        }
    }

    private void LateUpdate()
    {
        if (!DialogueControl.instance.isDialogueEnabled && isAttack)
        {
            animPrince.SetBool("attack", true);
            if (!isDesactiveControls)
                vsControls.OpacityControls(0.5f, false);
        }
    }

    public void FinalyAttack()
    {
        animPrince.SetBool("attack", false);
    }

    public void FadeOutAttack()
    {
        fadeUI.SetActive(true);
        vsControls.OpacityControls(1f, true);
        target.SetActive(false);
        CameraFollow.instance.FollowPlayer();
    }

}
