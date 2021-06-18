using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{

    [Header("Tutorial Controller")]
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private Text t_speechText;

    [Header("Data Extra")]
    public Player player;
    public GameObject controlsUI;

    public static TutorialControl instance;
    [SerializeField] private bool isTutorialEnabled = false;

    public void ActiveTutorial(Speech[] speechs)
    {
        tutorialUI.SetActive(true);
        player.RestartControls(false);
        player.playerInput.enabled = false;
        controlsUI.SetActive(false);
        isTutorialEnabled = true;
        StartCoroutine(WriteSpeech(speechs[0].speech));
    }

    IEnumerator WriteSpeech(string speech)
    {
        t_speechText.text = speech;
        yield return new WaitForSeconds(0.3f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
        {
            if (isTutorialEnabled)
            {
                tutorialUI.SetActive(false);
                controlsUI.SetActive(true);
                player.RestartControls(true);
                player.playerInput.enabled = true;
                isTutorialEnabled = false;
                Debug.Log("Desative");
            }
        }
    }
}
