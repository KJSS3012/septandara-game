using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [Header("Dialogue Controller")]
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private Text speechText;
    [SerializeField] private Text actorNameText;
    public Player player;
    public GameObject controlsUI;

    public static DialogueControl instance;

    private int length;
    private int index;
    private Speech[] speechs;
    [SerializeField] private bool isPass;
    private float writeSpeedSpeech = 0.06f;

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
                dialogueUI.SetActive(false);
                controlsUI.SetActive(true);
                player.RestartControls(true);
                player.playerInput.enabled = true;
                this.gameObject.SetActive(false);

            }
        }

        

    }


    public void ActiveDialogue(string actorName, string speech)
    {
        dialogueUI.SetActive(true);

        player.RestartControls(false);
        player.playerInput.enabled = false;
        controlsUI.SetActive(false);

        actorNameText.text = actorName;
        speechText.text = "";
        StartCoroutine(WriteSpeech(speech));
    }

    IEnumerator WriteSpeech(string speech)
    {
        foreach (char letter in speech.ToCharArray())
        {
            speechText.text += letter;
            if (speechText.text == speechs[index].speech)
            {
                StartCoroutine(DelayNextSpeech());
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

    public void GetDataDialogues(Speech[] speechs)
    {
        length = speechs.Length;
        this.speechs = speechs;
        ActiveDialogue(speechs[index].actorName, speechs[index].speech);
    }

}
