using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisintegratePlataform : MonoBehaviour
{

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            anim.SetBool("activeEffect", true);
        }
    }

    IEnumerator DelayReturn()
    {
        yield return new WaitForSeconds(3f);
        ReturnPlataform();
    }

    private void ReturnPlataform()
    {
        anim.SetBool("activeEffect", false);
        anim.SetBool("exit", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            StartCoroutine(DelayReturn());
        }
    }

    public void DesactiveExit()
    {
        anim.SetBool("exit", false);
    }

}
