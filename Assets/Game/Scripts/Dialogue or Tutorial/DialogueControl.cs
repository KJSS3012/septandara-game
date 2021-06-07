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

    [Header("Tutorial Controller")]
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private Text t_speechText;

    [Header("Data Extra")]
    public Player player;
    public GameObject controlsUI;

    public static DialogueControl instance;

    private int length;
    private int index;
    private Speech[] speechs;
    [SerializeField] private bool isPass;
    private float writeSpeedSpeech = 0.06f;
    public bool isTutorial;
    public bool isDown;

    private void Start()
    {
        instance = this;
        index = 0;
        length = -1;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
        {
            if (index < length - 1 && isPass)
            {
                isPass = false;
                index++;
                ActiveDialogue(speechs[index].actorName, speechs[index].speech);
            }
        }

        if (index == length && !isPass)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
            {
                if (!isTutorial)
                {
                    dialogueUI.SetActive(false);
                }
                else
                {
                    tutorialUI.SetActive(false);
                }
                controlsUI.SetActive(true);
                player.RestartControls(true);
                player.playerInput.enabled = true;
            }
        }
    }


    public void ActiveDialogue(string actorName, string speech)
    {
        Debug.Log(isTutorial);
        if (!isTutorial)
        {
            dialogueUI.SetActive(true);
            d_actorNameText.text = actorName;
            d_speechText.text = "";
        }
        else
        {
            tutorialUI.SetActive(true);
            t_speechText.text = "";
        }
        
        player.RestartControls(false);
        player.playerInput.enabled = false;
        controlsUI.SetActive(false);

        StartCoroutine(WriteSpeech(speech));
    }

    IEnumerator WriteSpeech(string speech)
    {
        foreach (char letter in speech.ToCharArray())
        {
            if (!isTutorial)
            {
                d_speechText.text += letter;
                if (d_speechText.text == speechs[index].speech && length != 1)
                {
                    StartCoroutine(DelayNextSpeech());
                }
            }
            else
            {
                t_speechText.text += letter;
                if (t_speechText.text == speechs[index].speech && length != 1)
                {
                    StartCoroutine(DelayNextSpeech());
                }
            }
            

            yield return new WaitForSeconds(writeSpeedSpeech);
        }

        if (index == length - 1)
        {
            isPass = false;
            index = length;
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

    public void GetDataDialogues(Speech[] speechs, bool isTutorial)
    {
        length = speechs.Length;
        this.speechs = speechs;
        this.isTutorial = isTutorial;
        index = 0;
        
        ActiveDialogue(speechs[index].actorName, speechs[index].speech);
    }

}
