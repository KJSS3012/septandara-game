using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] public SpeechsDialogue speechsActors;
    [SerializeField] private LayerMask layerCollider;
    [SerializeField] private float radiousCollider;
    [SerializeField] private bool isColliderDialogue;
    [SerializeField] private bool isActiveDialogue;
    public int lengthSpeechVector;
    public int indexSpeechActive;

    private void Start()
    {
        isActiveDialogue = false;
        lengthSpeechVector = 0;
        for (int s = 0; s < speechsActors.speechsDialogueObjects.Length; s++)
        {
            lengthSpeechVector++;
        }
        indexSpeechActive = 0;
    }

    private void FixedUpdate()
    {
        CheckColliderDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isColliderDialogue)
        {
            ShowDialogue();
        }
    }

    public void CheckColliderDialogue()
    {
        isColliderDialogue = Physics2D.OverlapCircle(transform.position, radiousCollider, layerCollider);
        if (isColliderDialogue)
        {
            isActiveDialogue = true;
        }
    }

    public void ShowDialogue()
    {
        Speech[] speechsDialogue = speechsActors.speechsDialogueObjects;
        GameController.instance.ActiveDialogue(speechsDialogue[indexSpeechActive].actorName, speechsDialogue[indexSpeechActive].speech);

    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radiousCollider);
    }

}
