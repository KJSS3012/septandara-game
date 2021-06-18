using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] public SpeechsDT speechsActors;
    [SerializeField] private bool isTutorialDialogue;
    public LayerMask layer;

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
        Speech[] speechsDialogue = speechsActors.speechsDialogueObjects;
        TutorialControl.instance.ActiveTutorial(speechsDialogue);
        isTutorialDialogue = false;
    }

}
