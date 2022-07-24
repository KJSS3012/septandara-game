using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactive : MonoBehaviour
{
    public Lupe lupe;

    private void Update()
    {
        DesactiveCanva();
    }

    public void DesactiveCanva()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
        {
            lupe.pictureUI.SetActive(false);
            lupe.vsControls.OpacityControls(1f, true);
            lupe.colliderLupe.enabled = true;
        }
    }

}
