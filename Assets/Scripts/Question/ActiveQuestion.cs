using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Animator question_animations;

    private void Start()
    {
        questionObj = FindObjectOfType<QuestionControl>();
        question_animations = GetComponent<Animator>();
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

    //Criar método para ler o arquivo JSON com as questões de determinada fase
    //Criar um objeto FASE com os atributos: Nome do mundo e número da fase (ou nome)
    //Criar duas variáveis públicas para recolher os dados do mundo e da fase ao qual determinada questão será inserida




    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
