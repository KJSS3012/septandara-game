using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] private int valueCoin;
    private Animator animCoin;
    public bool animSpin;

    private void Start()
    {
        animCoin = GetComponent<Animator>();
        ChangeSpinCoin(animSpin);
    }

    public void ChangeSpinCoin(bool other)
    {
        if (other)
        {
            animCoin.SetBool("other_spin", true);
        }
    }


    private void ColectCoin()
    {
        animCoin.SetBool("colect", true);

        GameController.instance.totalScoreCoins += valueCoin;
        GameController.instance.UpdateScoreCoins();

        Destroy(this.gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ColectCoin();
        }
    }



}
