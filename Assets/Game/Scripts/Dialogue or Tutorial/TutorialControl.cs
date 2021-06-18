using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{

    [Header("Tutorial Controller")]
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private Text t_speechText;

    public static TutorialControl instance;
    [SerializeField] private bool isTutorialEnabled = false;

    private void Start()
    {
        instance = this;
    }

    public void ActiveTutorial(Speech[] speechs)
    {
        tutorialUI.SetActive(true);
        isTutorialEnabled = true;
        StartCoroutine(WriteSpeech(speechs[0].speech));
    }

    IEnumerator WriteSpeech(string speech)
    {
        t_speechText.text = speech;
        yield return new WaitForSeconds(0.3f);
    }


    public void DesactiveUITutorial()
    {
        if (isTutorialEnabled)
        {
            tutorialUI.SetActive(false);
            isTutorialEnabled = false;
        }
    }

}
