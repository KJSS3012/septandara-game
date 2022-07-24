using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLoad : MonoBehaviour
{

    public GameObject[] questionsScene;
    public GameObject infoLoadSceneUI;
    public Text textUI;
    private bool isCollider;
    public GameObject indicator;

    private void Update()
    {
        GetQuestionInScene();
        VerifyQuestionsInScene();
    }

    private void GetQuestionInScene()
    {
        questionsScene = GameObject.FindGameObjectsWithTag("Question");
    }

    private void VerifyQuestionsInScene()
    {
        if (questionsScene.Length == 0)
        {
            indicator.SetActive(true);
            Destroy(this.gameObject);
        }
        if (isCollider)
        {
            {
                ShowMessageLock();
            }
        }
        else
        {
            DesactiveMessageLock();
        }
    }

    private void ShowMessageLock()
    {
        infoLoadSceneUI.SetActive(true);
        textUI.text = "Resolva todas as questões para prosseguir!";
    }

    private void DesactiveMessageLock()
    {
        infoLoadSceneUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollider = false;
    }

}
