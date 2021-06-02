using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Coin Controller")]
    public int totalScoreCoins;
    [SerializeField] private Text textScoreCoins;

    [Header("Heart Life Controller")]
    public int percentageLife;
    [SerializeField] private Text textPercentageHeart;

    public static GameController instance;

    private void Start()
    {
        instance = this;
        textPercentageHeart.text = percentageLife.ToString() + "%";
    }

    
    // MECHANICAL COINS
    public void UpdateScoreCoins()
    {
        if (totalScoreCoins < 100)
        {
            //ajustar exibição das moedas
        }
        textScoreCoins.text = totalScoreCoins.ToString();
    }


    //MECHANICAL HEARTS LIFE
    public void UpdatePercentageLife()
    {
        textPercentageHeart.text = percentageLife.ToString() + "%";
    }

}
