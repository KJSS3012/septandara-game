using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQuestion : MonoBehaviour
{

    [SerializeField] private QuestionsLevel questionsLevel;
    [SerializeField] private bool isColliderQuestion;
    [SerializeField] private bool isActive;
    public GameObject questionObject;
    [SerializeField] private AudioSource sound;


    private void Update()
    {
        if (isColliderQuestion && !isActive)
        {
            sound = GetComponent<AudioSource>();
            sound.Play();
            ShowQuestion();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isColliderQuestion = true;
        }
    }

    public void ShowQuestion()
    {
        QuestionControl.instance.ActiveQuestion(SortQuestionLevel());
        isActive = true;
        Destroy(questionObject, 1f);
    }

    public QuestionSheet SortQuestionLevel()
    {
        int indexQuestion = Random.Range(0, questionsLevel.questions.Length);

        if (QuestionControl.instance.GetContActivated() == questionsLevel.questions.Length)
        {
            QuestionControl.instance.ClearActivatedData();
        }

        while (questionsLevel.questions[indexQuestion].isActivated)
        {
            indexQuestion = Random.Range(0, questionsLevel.questions.Length);
        }

        questionsLevel.questions[indexQuestion].isActivated = true;
        QuestionControl.instance.AddContActivated();

        return questionsLevel.questions[indexQuestion];
    }

}
