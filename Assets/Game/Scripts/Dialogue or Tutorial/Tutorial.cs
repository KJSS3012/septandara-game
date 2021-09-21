using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private bool isTutorialDialogue;

    private void Start()
    {
        isTutorialDialogue = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTutorialDialogue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TutorialControl.instance.DesactiveUITutorial();
        }
    }

    public void Update()
    {
        if (isTutorialDialogue)
        {
            ShowTutorial();
        }
    }

    public void ShowTutorial()
    {
        TutorialControl.instance.ActiveTutorial();
        isTutorialDialogue = false;
    }

}
