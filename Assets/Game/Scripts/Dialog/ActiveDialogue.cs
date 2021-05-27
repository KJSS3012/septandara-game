using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogue : MonoBehaviour
{
    
    public string[] speechText;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
    bool onRadius;
    //criar uma variável para autorizar diálogos sem necessidade de clicar no 'S'

    private void Start() {

        dc = FindObjectOfType<DialogueControl>();

    }

    private void FixedUpdate(){
        ShowDialogue();
    }

    private void Update(){
        //Atualizar forma de ativar o diálogo
        if(onRadius){
            dc.Speech(speechText, actorName);
        }
    }

    public void ShowDialogue(){

        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null){
            onRadius = true;
        }else{
            onRadius = false;
        }

    }

    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
