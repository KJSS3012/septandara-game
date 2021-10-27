using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] public SpeechsDT speechsActors;
    private bool isCollisionPlayer;
    private bool isActiveDialogue;
    public bool isActiveDirectCollision;
    public bool isActiveIndirectCollision;
    public bool isActiveDirect;

    private void Update()
    {
        if (isActiveDirectCollision)
        {
            CollisionDirectTriggerActivate();
        }
        else if(isActiveIndirectCollision)
        {
            CollisionIndirectTriggerActivate();
        }
        else if(isActiveDirect)
        {
            DirectTriggerActive();
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

    private void DirectTriggerActive()
    {
        ShowDialogue();
        isActiveDirect = false;
    }

    private void CollisionDirectTriggerActivate() //Ativar direto
    {
        if (isCollisionPlayer && !isActiveDialogue)
        {
            ShowDialogue();
        }
    }

    private void CollisionIndirectTriggerActivate() //Ativar tando dentro do trigger e acionando uma tecla/botão na tela
    {

        if (isCollisionPlayer && (Input.GetKeyDown(KeyCode.S) || Input.GetMouseButtonDown(0)) && !isActiveDialogue)
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
