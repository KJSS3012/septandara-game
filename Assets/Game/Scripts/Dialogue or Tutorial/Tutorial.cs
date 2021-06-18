using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] public SpeechsDT speechsActors;
    private bool isTutorialDialogue;
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
        else
        {
            isTutorialDialogue = false;
        }
        Debug.Log(isTutorialDialogue);
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
    }

}
