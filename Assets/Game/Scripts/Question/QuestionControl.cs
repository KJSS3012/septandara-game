using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject questionUI;
    public Text enunciatedText;
    public Text alternative_A;
    public Text alternative_B;
    public Text alternative_C;
    public Text alternative_D;
    public Image imageQuestion;

    private int alternativeCorrect;
    public int contActivated;


    public static QuestionControl instance;
    [SerializeField] private QuestionsLevel questionsLevel;

    private void Start()
    {
        instance = this;
        contActivated = 0;

        //zerar o isActivated de todas as questões quando iniciar o objeto
        ClearActivatedData();
    }


    public void ActiveQuestion(QuestionSheet question)
    {
        questionUI.SetActive(true);
        enunciatedText.text = question.enunciated;
        alternative_A.text = question.alternative_A;
        alternative_B.text = question.alternative_B;
        alternative_C.text = question.alternative_C;
        alternative_D.text = question.alternative_D;
        alternativeCorrect = question.alternativeCorrect;
    }

    public void ClearActivatedData()
    {
        for (int index = 0; index < questionsLevel.questions.Length; index++)
        {
            questionsLevel.questions[index].isActivated = false;
        }
        contActivated = 0;
    }

    public void AddContActivated()
    {
        contActivated++;
    }

    public int GetContActivated()
    {
        return contActivated;
    }


    public void Desactive()
    {
        questionUI.SetActive(false);
    }



}
