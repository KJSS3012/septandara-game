using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin")]
    // define valor para cada moeda coletada
    [SerializeField] private int valueCoin = 10;
    // atribui a animCoin o animator
    private Animator animCoin;
     // atribui a sound o AudioSource
    private AudioSource sound;
    public bool animSpin;

    private void Start()
    {   
        // animCoin recebe componentes do animator
        animCoin = GetComponent<Animator>();
        // sound recebe componentes do AudioSource
        sound = GetComponent<AudioSource>();
        // instancia do metodo da animação da moeda
        ChangeSpinCoin(animSpin);
    }


    // metodo que anima a moeda
    public void ChangeSpinCoin(bool other)
    {
        if (other)
        {
            animCoin.SetBool("other_spin", true);
        }
    }
    // metodo para quando uma moeda for coletada
    private void ColectCoin()
    {
        // ativa animação da moeda sendo coletada
        animCoin.SetBool("colect", true);
        // ativa o som de coleta
        sound.Play();
        
        // soma o valor de moedas coletadas ao total e salva
        GameController.instance.totalScoreCoins += valueCoin;
        GameController.instance.UpdateScoreCoins();
        // destroi o objeto da moeda após a colisão
        Destroy(this.gameObject, 0.5f);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // compara se foi o player que colidiu
        // caso o player colida com a moeda, o metodo ColectCoin é usado
        if (collision.gameObject.CompareTag("Player"))
        {
            ColectCoin();
        }
    }

}
