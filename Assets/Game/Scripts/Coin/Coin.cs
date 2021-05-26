using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int valueCoin;
    private Animator animCoin;
    public bool animSpin;
    public LayerMask playerLayer;

    private void Start()
    {
        animCoin = GetComponent<Animator>();
        ChangeSpinCoin(animSpin);
    }

    public int GetValueCoin()
    {
        return valueCoin;
    }

    public void ChangeSpinCoin(bool other)
    {
        if (other)
        {
            animCoin.SetBool("other_spin", true);
        }
    }


    public void ColectCoin()
    {
        animCoin.SetBool("colect", true);

        GameController.instance.totalScoreCoins += valueCoin;
        GameController.instance.UpdateScoreCoins();

        Destroy(this.gameObject, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ColectCoin();
        }
    }



}
