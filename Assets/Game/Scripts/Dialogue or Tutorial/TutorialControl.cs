using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{

    [Header("Tutorial Controller")]
    [SerializeField] private GameObject tutorialUI;

    public static TutorialControl instance;
    [SerializeField] private bool isTutorialEnabled = false;

    private void Start()
    {
        instance = this;
    }

    public void ActiveTutorial()
    {
        tutorialUI.SetActive(true);
        isTutorialEnabled = true;
    }

    public void DesactiveUITutorial()
    {
        if (isTutorialEnabled)
        {
            tutorialUI.SetActive(false);
            isTutorialEnabled = false;
        }
    }

}
