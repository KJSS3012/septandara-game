using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogue : MonoBehaviour
{
    
    public string speechText;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;

    private void Start() {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate(){
        ShowDialogue();
    }

    public void ShowDialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null){
            dc.Speech(speechText, actorName);
        }

    }

    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
