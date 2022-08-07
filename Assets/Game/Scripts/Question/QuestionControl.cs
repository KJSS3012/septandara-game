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
    public Text resultsClick;
    public Image imageQuestion;
    public Animator animQuestion;
    private int alternativeCorrect;
    private int contActivated;
    private bool isMissChance;
    private VisibilityControls vsControls;
    public static QuestionControl instance;
    public QuestionsLevel questionsLevel;

    private void Start()
    {
        instance = this;
        contActivated = 0;
        isMissChance = false;
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();

        //zerar o isActivated de todas as quest�es quando iniciar o objeto
        ClearActivatedData();
    }

    public void ActiveQuestion(QuestionSheet question)
    {
        questionUI.SetActive(true);
        vsControls.OpacityControls(0.5f, false);
        vsControls.EnemysPause(false);

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

    public void ClickAlternative(int valueAlternative)
    {
        if (alternativeCorrect == valueAlternative)
        {
            resultsClick.text = "Correto";
            isMissChance = false;
            GameController.instance.concecutiveCorrectQuestion++;
            GameController.instance.UpdateConsecutiveQuestion();
        }
        else
        {
            resultsClick.text = "Errado";
            isMissChance = true;
            GameController.instance.concecutiveCorrectQuestion = 0;
            GameController.instance.UpdateConsecutiveQuestion();
        }

        resultsClick.gameObject.SetActive(true);

        StartCoroutine(DelayDesactiveQuestion());

        animQuestion.SetBool("exit", true);
        vsControls.OpacityControls(1f, true);
        vsControls.EnemysPause(true);

        GameController.instance.VerifyChances(isMissChance);
    }

    IEnumerator DelayDesactiveQuestion()
    {
        yield return new WaitForSeconds(2);
        questionUI.SetActive(false);
        resultsClick.gameObject.SetActive(false);
    }

}