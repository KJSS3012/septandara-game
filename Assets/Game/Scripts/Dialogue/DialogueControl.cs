using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [Header("Dialogue Controller")]
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private Text d_speechText;
    [SerializeField] private Text d_actorNameText;
    [SerializeField] private float writeSpeedSpeech = 0.04f;
    public bool isDialogueEnabled;
    
    [Header("Data Extra")]
    public VisibilityControls vsControls;

    public static DialogueControl instance;
    private int length;
    private int index;
    private Speech[] speechs;
    private bool isPass;

    public bool isDesactiveControls; //For timeline

    private void Start()
    {
        instance = this;
        index = 0;
        length = 0;
        if (!isDesactiveControls)
        {
            vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
        }
    }

    private void Update()
    {
        //Passa a fala
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
        {
            
            if (index <= length - 1 && isPass)
            {
                isPass = false;
                index++;
                d_speechText.text = "";
                if (index <= length-1)
                    ActiveDialogue(speechs[index].actorName, speechs[index].speech);
            }
            else if (!isPass && length != 1 && speechs != null)
            {
                if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S)))
                {
                    d_actorNameText.text = speechs[index].actorName;
                    d_speechText.text = speechs[index].speech;
                    StartCoroutine(DelayNextSpeech());
                    AlterVariables();
                }
            }
        }

        if (index == length && !isPass && isDialogueEnabled)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
            {
                FinalyDialogue();
            }
        }
    }

    private void FinalyDialogue()
    {
        dialogueUI.SetActive(false);
        isDialogueEnabled = false;
        if (!isDesactiveControls) { 
            vsControls.OpacityControls(1f, true);
            GameController.instance.ReactiveChances();
        }
    }

    public void ActiveDialogue(string actorName, string speech)
    {
        d_actorNameText.text = actorName;
        d_speechText.text = "";
        isDialogueEnabled = true;
        StartCoroutine(WriteSpeech(speech));
    }

    IEnumerator WriteSpeech(string speech)
    {
        foreach (char letter in speech.ToCharArray())
        { 
            if (d_speechText.text != speechs[index].speech)
            {
                d_speechText.text += letter;
                if (d_speechText.text == speechs[index].speech && length != 1)
                {
                    StartCoroutine(DelayNextSpeech());
                }
                yield return new WaitForSeconds(writeSpeedSpeech);
            }
            else
            {
                break;
            }
        }
        AlterVariables();
    }

    public void AlterVariables()
    {
        if (index == length)
        {
            isPass = false;
        }
        else
        {
            isPass = true;
        }
    }

    IEnumerator DelayNextSpeech()
    {
        yield return new WaitForSeconds(0.3f);
    }

    public void GetDataDialogues(Speech[] speechs)
    {
        length = speechs.Length;
        this.speechs = speechs;
        index = 0;
        dialogueUI.SetActive(true);
        isDialogueEnabled = true;
        if (!isDesactiveControls)
            vsControls.OpacityControls(0.5f, false);
        ActiveDialogue(speechs[index].actorName, speechs[index].speech);
    }

}
