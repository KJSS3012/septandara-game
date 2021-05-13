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


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
