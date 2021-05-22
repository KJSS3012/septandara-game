using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ActiveQuestion : MonoBehaviour
{

    public string enunciated;
    public string altA;
    public string altB;
    public string altC;
    public string altD;

    public LayerMask playerLayer;
    public float radious;

    private QuestionControl questionObj;
    private bool OnRadius;

    private void Start()
    {
        questionObj = FindObjectOfType<QuestionControl>();

        

    }

    private void FixedUpdate()
    {
        IndetifyPlayer();
    }

    private void Update()
    {
        if (OnRadius)
        {
            questionObj.ShowQuestion(enunciated, altA, altB, altC, altD);
            //GetQuestions();
        }
    }


    public void IndetifyPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if (hit != null)
        {
            OnRadius = true;
        }
        else
        {
            OnRadius = false;
        }
    }

    public void GetQuestions()
    {
        Debug.Log(Application.dataPath);

        

        if (File.Exists(Application.dataPath + "/JSONFiles/JSONQuestions/teste.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/JSONFiles/JSONQuestions/teste.json");
            Debug.Log(json);
        }

        //return null;
    }


    //Criar método para ler o arquivo JSON com as questões de determinada fase
    //Criar um objeto FASE com os atributos: Nome do mundo e número da fase (ou nome)
    //Criar duas variáveis públicas para recolher os dados do mundo e da fase ao qual determinada questão será inserida




    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
