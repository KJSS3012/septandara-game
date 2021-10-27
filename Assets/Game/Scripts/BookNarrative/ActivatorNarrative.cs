using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorNarrative : MonoBehaviour
{
    public BookNarrative bookNarrative;

    public void OpenNarrative()
    {
        bookNarrative.bookNarrativeUI.SetActive(true);
        bookNarrative.player.RestartControls(false);
        bookNarrative.vsControls.OpacityControls(0.5f, false);
        bookNarrative.colliderCapsule.enabled = false;
    }

    public void CloseNarrative()
    {
        bookNarrative.bookNarrativeUI.SetActive(false);
        bookNarrative.player.RestartControls(true);
        bookNarrative.vsControls.OpacityControls(1f, true);
        bookNarrative.colliderCapsule.enabled = true;
        bookNarrative.altarObject.GetComponent<Animator>().SetBool("open", false);
    }
}
