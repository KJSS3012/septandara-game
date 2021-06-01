using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] public SpeechsDialogue speechsActors;
    [SerializeField] private bool isActiveDirect;
    private bool isCollisionPlayer;
    private bool isActiveDialogue;


    private void Start()
    {
        isActiveDialogue = false;
    }

    private void Update()
    {
        if (isActiveDirect)
        {
            DirectTriggerActivate();
        }
        else
        {
            IndirectTriggerActivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollisionPlayer = true;
        }
        else
        {
            isCollisionPlayer = false;
        }
    }

    private void DirectTriggerActivate() //Ativar direto
    {
        if (isCollisionPlayer && !isActiveDialogue)
        {
            ShowDialogue();
        }
    }

    private void IndirectTriggerActivate() //Ativar tando dentro do trigger e acionando uma tecla/botão na tela
    {

        if (isCollisionPlayer && Input.GetKeyDown(KeyCode.S) && !isActiveDialogue)
        {
            ShowDialogue();
        }

    }


    private void ShowDialogue()
    {
        Speech[] speechsDialogue = speechsActors.speechsDialogueObjects;
        DialogueControl.instance.GetDataDialogues(speechsDialogue);
        isActiveDialogue = true;
    }

    

}
