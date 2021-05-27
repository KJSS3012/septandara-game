using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Coin Controller")]
    public int totalScoreCoins;
    public Text textScoreCoins;

    [Header("Dialogue Controller")]




    public static GameController instance;

    private void Start()
    {
        instance = this;
    }


    public void UpdateScoreCoins()
    {
        if (totalScoreCoins < 100)
        {
            //ajustar exibição das moedas
        }
        textScoreCoins.text = totalScoreCoins.ToString();
    }

}
