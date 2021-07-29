using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactive : Lupe
{

    private void Start()
    {
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pictureUI.SetActive(false);
            vsControls.OpacityControls(1f, true);
            colliderLupe.enabled = true;
        }
    }
}
