using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince : MonoBehaviour
{
    private Animator animPrince;
    public GameObject fadeUI;
    public bool isAttack;

    private void Start()
    {
        animPrince = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (!DialogueControl.instance.isDialogueEnabled && isAttack)
        {
            animPrince.SetBool("attack", true);
        }
    }

    public void FinalyAttack()
    {
        animPrince.SetBool("attack", false);
    }

    public void FadeOutAttack()
    {
        fadeUI.SetActive(true);
    }

}
