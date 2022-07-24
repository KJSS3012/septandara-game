using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDesactive : MonoBehaviour
{

    private VisibilityControls vsControls;
    public GameObject showCardUI;

    private void Start()
    {
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            showCardUI.SetActive(false);
            vsControls.OpacityControls(1f, true);
        }
    }
}
