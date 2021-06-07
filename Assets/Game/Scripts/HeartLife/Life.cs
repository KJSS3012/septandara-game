using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    [Header("Heart Life")]

    private int partLife = 20; //20%, ou seja, serão 5 vidas no total
    private Animator animHeartLife;

    private void Start()
    {
        animHeartLife = GetComponent<Animator>();
    }

    private void ColectHeart()
    {
        animHeartLife.SetBool("colect", true);

        if (!(GameController.instance.percentageLife == 100))
        {
            GameController.instance.percentageLife += partLife;
            GameController.instance.UpdatePercentageLife();
        }

        Destroy(this.gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColectHeart();
        }
    }


}
